import { Component, OnInit, Input } from '@angular/core';
import { SocketDevice } from 'src/app/Models/SocketDevice';

@Component({
  selector: 'app-socket',
  templateUrl: './socket.component.html',
  styleUrls: ['./socket.component.scss']
})
export class SocketComponent implements OnInit {

  @Input()
  device!: SocketDevice;

  constructor() {
  }

  ngOnInit(): void {
  }

}
