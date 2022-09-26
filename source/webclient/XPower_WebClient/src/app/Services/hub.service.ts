import { Injectable } from '@angular/core';
import { HubDevice } from '../Models/HubDevice';

@Injectable({
  providedIn: 'root'
})
export class HubService {


  /*
  Array of all the avaible devices.
  */
  private hubDevices: Array<HubDevice> = new Array<HubDevice>();

  constructor() {
    
  }

  /*
  Retrieves the socket devices from the hub
  */
  public GetHubDevicesFromHome(home_idenfitifer: string) : void {
    //An offline hub for testing
    let a = new HubDevice();
    a.status = false;

    this.hubDevices = [
      new HubDevice(),
      new HubDevice(),
      a,
      new HubDevice(),
      new HubDevice(),
      new HubDevice(),
      new HubDevice(),
    ];
  }

  /*
  Returns all the devices
  */
  public GetDevices() : Array<HubDevice> {
    return this.hubDevices;
  }

  /*
  Returns array of devices specified from the the given type
  */
  public GetFilteredDevices<T extends HubDevice>(type: new (...params : any[]) => T) : Array<T>{
     let HubDevices = Array<T>();

    this.hubDevices.forEach(dev => {
      if (dev instanceof type)
        HubDevices.push(dev as T);
    });

    return HubDevices;
  }
}
