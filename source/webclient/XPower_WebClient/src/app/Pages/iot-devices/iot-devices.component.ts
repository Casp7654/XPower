import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { SocketDevice } from 'src/app/Models/SocketDevice';
import { IoTService } from 'src/app/Services/io-t.service';

@Component({
  selector: 'app-iot-devices',
  templateUrl: './iot-devices.component.html',
  styleUrls: ['./iot-devices.component.scss']
})
export class IotDevicesComponent implements OnInit {

  devices = this.iot_service.GetSocketDevices();
  columnAmount: number = 2;

  constructor(
    private iot_service: IoTService
  ) 
  {
    this.iot_service.GetSocketDevicesFromHub("");
    this.devices = this.iot_service.GetSocketDevices();
    this.changeColumnsFromWidth(window.innerWidth);
  }

  ngOnInit(): void {
  }

  onResize(event : any): void {
    this.changeColumnsFromWidth(event.target.innerWidth);
  }

  private changeColumnsFromWidth(width: number): void {
    this.columnAmount = (width <= 600) ? 2 : 4;
  }

}
