import { Injectable } from '@angular/core';
import { HubDevice } from '../Models/HubDevice';
import { IoTDevice } from '../Models/IoTDevice';
import { SocketDevice } from '../Models/SocketDevice';
import { MqttClientService } from './mqtt-client.service';
import { DeviceStatus } from '../Models/Dtos/DeviceStatus';
import { DeviceType } from '../Models/Dtos/DeviceType';
import { SocketDeviceStatus } from '../Models/Dtos/SocketDeviceStatus';
import { DeviceStatusResponse } from '../Models/Dtos/DeviceStatusResponse';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IoTService {

  private devices: Array<IoTDevice> = new Array<IoTDevice>();
  public observableDevices$: Observable<SocketDevice[]> = of(this.devices as Array<SocketDevice>);

  constructor(private mqttService: MqttClientService) {
    mqttService.Subscribe("StatusResponse/all", (msg: string) => this.onIoTStatusResponse(msg));
  }

  /**
   * Sends request to hub to get devices
   * @param hub_idenfitifer The hub identifier to request from
   */
  public GetSocketDevicesFromHub(hub_idenfitifer: string) : void {
    this.mqttService.Publish("StatusRequest/all", "");
  }

  /**
   * @returns All devices
   */
  public GetDevices() : Array<IoTDevice> {
    return this.devices;
  }

  /**
   * @param type The IoTDevice to look for
   * @returns array of devices specified from the the given type
   */
  public GetFilteredDevices<T extends IoTDevice>(type: new (...params : any[]) => T) : Array<T>{
    let socketDevices = Array<T>();

    this.devices.forEach(dev => {
      if (dev instanceof type)
        socketDevices.push(dev as T);
    });

    return socketDevices;
  }

  /**
   * Finds device in IoT devices array by given client id
   * @param clientId The id to look for
   * @returns IoTDevice if found undefined if not
   */
  private getDeviceById(clientId: string) : IoTDevice | undefined {
    return this.devices
      .find((dev) => dev.name == clientId);
  }

  /**
   * Either creates a new socket device or updates the exisisting one
   * With the new status data.
   * @param status The new status for the device.
   */
   private onSocketStatusResponse(status: DeviceStatusResponse<SocketDeviceStatus>) : void {
    let knownDevice = this.getDeviceById(status.Device.ClientId) as SocketDevice;

    if (knownDevice === undefined) {
      // Create new device
      this.devices.push(new SocketDevice(
        status.Device.ClientId,
        status.Device.StatusId > 0,
        status.Device.MacAddress,
        status.Data.TurnedOn,
        "Home",
        new HubDevice(),
      ));
    }
    else {
      // Update device
      knownDevice.status = status.Device.StatusId > 0;
      knownDevice.turned_on = status.Data.TurnedOn;
    }
  }

  /**
   * Called when a IoT device response comes in with a status
   * @param message The application message from the device
   */
  private onIoTStatusResponse(message: string) : void {
    if (!message)
      return;

    let jsonObjs: any[] = JSON.parse(message);

    jsonObjs.forEach((obj) => {
      let device = obj['Device'] as DeviceStatus;

      switch(device.TypeId) {
        // TODO: Find parent hub
        case DeviceType.Socket:
          let socketResponse = obj as DeviceStatusResponse<SocketDeviceStatus>;
          this.onSocketStatusResponse(socketResponse);
          break;
      };
    });
  }
}