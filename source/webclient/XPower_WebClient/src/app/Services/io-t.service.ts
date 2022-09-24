import { Injectable } from '@angular/core';
import { HubDevice } from '../Models/HubDevice';
import { IoTDevice } from '../Models/IoTDevice';
import { SocketDevice } from '../Models/SocketDevice';

@Injectable({
  providedIn: 'root'
})
export class IoTService {

  /*
  Array of all the avaible devices.
  */
  private devices: Array<IoTDevice> = new Array<IoTDevice>();

  constructor() {
    
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
}
