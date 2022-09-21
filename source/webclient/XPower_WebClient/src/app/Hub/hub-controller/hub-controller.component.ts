import { Component, OnInit } from '@angular/core';
import { HubModule } from '../hub/hub.module';

@Component({
  selector: 'app-hub-controller',
  templateUrl: './hub-controller.component.html',
  styleUrls: ['./hub-controller.component.scss']
})
export class HubControllerComponent implements OnInit {
public hubs! : HubModule[];
  constructor() { }

  ngOnInit(): void {
    this.hubs = this.LoadHubsFromHome();
  }

  LoadHubsFromHome(homeName = "Alle") : HubModule[]{

    //Do some api call to fetch all the hubs from home 
    let hub = new HubModule("123", "Hub 1");
    let hubArray : HubModule[] = [hub];

    return hubArray;
  }

}
