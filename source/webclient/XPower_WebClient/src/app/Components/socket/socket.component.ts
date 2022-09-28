import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { SocketDevice } from 'src/app/Models/SocketDevice';

@Component({
  selector: 'app-socket',
  templateUrl: './socket.component.html',
  styleUrls: ['./socket.component.scss']
})
export class SocketComponent implements OnInit {

  /*
  The current device which will be rendered
  */
  @Input()
  device!: SocketDevice;

  /*
  The event emitted when the device should be turned off / on
  */
  @Output()
  onToggleDeviceClick = new EventEmitter<SocketDevice>();

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
