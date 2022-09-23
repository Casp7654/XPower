import { Injectable } from '@angular/core';
import { HubDevice } from '../Models/HubDevice';
import { SocketDevice } from '../Models/SocketDevice';

@Injectable({
  providedIn: 'root'
})
export class IoTService {

  private sockets: Array<SocketDevice> = new Array<SocketDevice>();

  constructor() {
    
  }

  public GetSocketDevicesFromHub(hub_idenfitifer: string) : void {

    let hub = new HubDevice();
    
    this.sockets = [
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

  public GetSocketDevices() : Array<SocketDevice>{
    return this.sockets;
  }
}
