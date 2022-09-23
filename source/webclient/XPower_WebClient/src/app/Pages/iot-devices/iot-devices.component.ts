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

  constructor(
    private iot_service: IoTService
  ) 
  {
    this.iot_service.GetSocketDevicesFromHub("");
    this.devices = this.iot_service.GetSocketDevices();
  }

  ngOnInit(): void {
  }

}
