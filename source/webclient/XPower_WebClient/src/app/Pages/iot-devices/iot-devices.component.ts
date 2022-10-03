import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { HubDevice } from 'src/app/Models/HubDevice';
import { SocketDevice } from 'src/app/Models/SocketDevice';
import { IoTService } from 'src/app/Services/io-t.service';
import { SocketDeviceService } from 'src/app/Services/socket-device.service';

@Component({
  selector: 'app-iot-devices',
  templateUrl: './iot-devices.component.html',
  styleUrls: ['./iot-devices.component.scss']
})
export class IotDevicesComponent implements OnInit {

  /*
  All the devices which should be rendered
  */
  devices: SocketDevice[];

  /*
  The amount of columns
  */
  columnAmount: number = 2;

  toggle = false;

  constructor(private iot_service: IoTService,
    private socketDeviceService: SocketDeviceService) 
  {
    this.iot_service.GetSocketDevicesFromHub("");
    this.devices = this.iot_service.GetFilteredDevices(SocketDevice);
    this.changeColumnsFromWidth(window.innerWidth);
  }

  ngOnInit(): void {
  }

  /*
  Called when resize of window is called
  */
  onResize(event : any): void {
    this.changeColumnsFromWidth(event.target.innerWidth);
  }

  /*
  Called when a device should be turned on / off
  */
  OnToggleDeviceClicked(device : SocketDevice): void {
    if (this.toggle)
      this.socketDeviceService.TurnOff(device.name);
    else
      this.socketDeviceService.TurnOn(device.name);

    this.toggle = !this.toggle;
  }

  /*
  Calculates the current width and decided whether there should be 2 or 4 columns
  */
  private changeColumnsFromWidth(width: number): void {
    this.columnAmount = (width <= 600) ? 2 : 4;
  }

}
