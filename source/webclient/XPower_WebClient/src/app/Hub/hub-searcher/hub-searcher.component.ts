import { Component, OnInit, NgZone, Inject } from '@angular/core';
import { HubConnServiceService  } from './hub-conn-service.service';
import { BluetoothCore } from '@manekinekko/angular-web-bluetooth';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-hub-searcher',
  templateUrl: './hub-searcher.component.html',
  styleUrls: ['./hub-searcher.component.scss']
})
export class HubSearcherComponent implements OnInit {
  device: any = {};
  credentials: FormGroup;
  isConnected : boolean = false
  connectedField = this.isConnected ? "block" : "none";

  constructor(public _hubConnService: HubConnServiceService,
    fb: FormBuilder)
    {
      this.credentials = fb.group({
        hideRequired: false,
        floatLabel: 'auto',
        apariencia: 'fill',
        fbssid : '',
        fbpassphrase : ''
      });
    }

  ngOnInit(): void {
    this.getDeviceStatus();
  }

  connected(value: any){
    this.isConnected = true;
  }

  connect(){
    this._hubConnService?.getCharConnect()?.subscribe(this.connected.bind(this));
  }

  getDeviceStatus() {
    this._hubConnService.getDevice().subscribe((device) => {
      if (device) {
        this.device = device;
      }
      else
      {
        // device not connected or disconnected
        this.device = null;
        this.isConnected = false;
      }
    });
  }

  async sendinput(){
    const encoder = new TextEncoder();
    // json convert to ssid and password
    var obj:any = {}
    obj.ID = 0;
    obj.SSID = this.credentials.value.fbssid;
    obj.PassPhrase =  this.credentials.value.fbpassphrase;

    var jStr = JSON.stringify(obj);
    let encodedString = encoder.encode(jStr);

   // Try with response, but after it changes the ip
    await this._hubConnService.getCharacter().writeValueWithoutResponse(encodedString);
  }
}
