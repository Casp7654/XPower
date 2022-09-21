import { Component, Injectable, Input, OnInit } from '@angular/core';
import { HubModule } from '../hub/hub.module';

@Component({
  selector: 'app-hub-component',
  templateUrl: './hub-component.component.html',
  styleUrls: ['./hub-component.component.scss']
})
export class HubComponentComponent implements OnInit {
  @Input()
  public hub! : HubModule;

  constructor() { }

  ngOnInit(): void {
  }

}
