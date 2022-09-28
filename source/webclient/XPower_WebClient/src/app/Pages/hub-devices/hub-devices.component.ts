import { Component, OnInit } from '@angular/core';
import { HubDevice } from 'src/app/Models/HubDevice';
import { HubService } from 'src/app/Services/hub.service';

@Component({
  selector: 'app-hub-devices',
  templateUrl: './hub-devices.component.html',
  styleUrls: ['./hub-devices.component.scss']
})
export class HubDevicesComponent implements OnInit {

   /*
  All the devices which should be rendered
  */
  hubDevices: HubDevice[];

  /*
  The amount of columns
  */
  columnAmount: number = 2;

  constructor(private hub_service: HubService) 
  {
    this.hub_service.GetHubDevicesFromGroup("");
    this.hubDevices = this.hub_service.GetFilteredDevices(HubDevice);
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
  OnToggleDeviceClicked($device : HubDevice): void {
    console.log($device.name);
  }

  /*
  Calculates the current width and decided whether there should be 2 or 4 columns
  */
  private changeColumnsFromWidth(width: number): void {
    this.columnAmount = (width <= 600) ? 2 : 4;
  }
}
