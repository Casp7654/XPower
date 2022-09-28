import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { HubDevice } from 'src/app/Models/HubDevice';

@Component({
  selector: 'app-hub',
  templateUrl: './hub.component.html',
  styleUrls: ['./hub.component.scss']
})
export class HubComponent implements OnInit {

/*
  The current device which will be rendered
  */
  @Input()
  device!: HubDevice;

  /*
  The event emitted when the device should be turned off / on
  */
  @Output()
  onToggleDeviceClick = new EventEmitter<HubDevice>();

  constructor() {
  }

  ngOnInit(): void {
  }

  /*
  Event for when card is double clicked
  */
  onDblClickEvent(event : any): void {
    this.onToggleDeviceClick.emit(this.device);
  }

}
