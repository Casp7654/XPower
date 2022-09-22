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
    let hub2 = new HubModule("123", "Hub 3");
    let hub3 = new HubModule("123", "Hub 3");
    let hub4 = new HubModule("123", "Hub 4");
    let hub5 = new HubModule("123", "Hub 5");
    let hub6 = new HubModule("123", "Hub 6");
    let hub7 = new HubModule("123", "Hub 7");
    let hub8 = new HubModule("123", "Hub 8");
    let hubArray : HubModule[] = [hub, hub2, hub3, hub4, hub5, hub6, hub7, hub8];

    return hubArray;
  }

}
