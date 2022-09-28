import { Injectable } from '@angular/core';
import { HubDevice } from '../Models/HubDevice';
import { IoTDevice } from '../Models/IoTDevice';
import { SocketDevice } from '../Models/SocketDevice';
import { MqttClientService } from './mqtt-client.service';

@Injectable({
  providedIn: 'root'
})
export class IoTService {

  /*
  Array of all the avaible devices.
  */
  private devices: Array<IoTDevice> = new Array<IoTDevice>();

  constructor(private mqttService: MqttClientService) {
    mqttService.Subscribe("StatusResponse/all", this.onIoTStatusResponse);
  }

  /*
  Retrieves the socket devices from the hub
  */
  public GetSocketDevicesFromHub(hub_idenfitifer: string) : void {

    let hub = new HubDevice();
    
    this.devices = [
      new SocketDevice("Device1", true, "MAC:18:1238:asd", true, "Hjemme", hub),
      new SocketDevice("Device2", true, "MAC:18:1238:asd", false, "Hjemme", hub),
      new SocketDevice("Device3", false, "MAC:18:1238:asd", true, "Hjemme", hub),
      new SocketDevice("Device4", true, "MAC:18:1238:asd", true, "Hjemme", hub),
      new SocketDevice("Device4", true, "MAC:18:1238:asd", true, "Hjemme", hub),
      new SocketDevice("Device4", true, "MAC:18:1238:asd", true, "Hjemme", hub),
      new SocketDevice("Device4", true, "MAC:18:1238:asd", true, "Hjemme", hub),
      new SocketDevice("Device4", true, "MAC:18:1238:asd", true, "Hjemme", hub),
      new SocketDevice("Device4", true, "MAC:18:1238:asd", true, "Hjemme", hub),
      new SocketDevice("Device4", true, "MAC:18:1238:asd", true, "Hjemme", hub),
      new SocketDevice("Device4", true, "MAC:18:1238:asd", true, "Hjemme", hub),
      new SocketDevice("Device4", true, "MAC:18:1238:asd", true, "Hjemme", hub),
    ];
  }

  /*
  Returns all the devices
  */
  public GetDevices() : Array<IoTDevice> {
    return this.devices;
  }

  /*
  Returns array of devices specified from the the given type
  */
  public GetFilteredDevices<T extends IoTDevice>(type: new (...params : any[]) => T) : Array<T>{
    let socketDevices = Array<T>();

    this.devices.forEach(dev => {
      if (dev instanceof type)
        socketDevices.push(dev as T);
    });

    return socketDevices;
  }

  private getDeviceById(clientId: string) : IoTDevice | undefined {
    return this.devices
      .find((dev) => dev.name == clientId);
  }

  private onIoTStatusResponse(message: string) : void {
    let obj = JSON.parse(message);
    let clientStatus = obj as ClientStatusResponse[];

    clientStatus.forEach((status) => {
      let dev = this.getDeviceById(status.ClientId);
      dev!.status = status.StatusId as number > 0;
    });
  }
}
