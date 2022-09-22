import { Component, Input, OnInit } from '@angular/core';
import { HubModule } from './hub.module';

@Component({
  selector: 'app-hub',
  templateUrl: './hub.component.html',
  styleUrls: ['./hub.component.scss']
})
export class HubComponent implements OnInit {
  @Input() hub! : HubModule;

  constructor() { }

  ngOnInit(): void {
  }

}
