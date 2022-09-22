import { Component, OnInit } from '@angular/core';
import { IotModule } from '../iot/iot.module';

@Component({
  selector: 'app-iot-controller',
  templateUrl: './iot-controller.component.html',
  styleUrls: ['./iot-controller.component.scss']
})
export class IotControllerComponent implements OnInit {
  public iots! : IotModule[];
  constructor() { }

  ngOnInit(): void {
    this.iots = this.LoadIotsFromHub();
  }
  LoadIotsFromHub(hubName = "Hub 1") : IotModule[]{

    //Do some api call to fetch all the iots from hub
    let iot = new IotModule("123", "Hub 1");
    let iot2 = new IotModule("123", "Hub 1");
    let iot3 = new IotModule("123", "Hub 1");
    let iot4 = new IotModule("123", "Hub 1");
    let iot5 = new IotModule("123", "Hub 1");
    let iot6 = new IotModule("123", "Hub 1");
    let iot7 = new IotModule("123", "Hub 1");
    let iot8 = new IotModule("123", "Hub 1");
    let iotArray : IotModule[] = [iot, iot2, iot3, iot4, iot5, iot6, iot7, iot8];

    return iotArray;
  }
}
