import { Component, Input, OnInit } from '@angular/core';
import { IotModule } from './iot.module';

@Component({
  selector: 'app-iot',
  templateUrl: './iot.component.html',
  styleUrls: ['./iot.component.scss']
})
export class IotComponent implements OnInit {
  @Input() iot! : IotModule;
  constructor() { }

  ngOnInit(): void {
  }

}
