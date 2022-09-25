import { Component, OnInit, NgZone, Inject } from '@angular/core';
import { HubConnServiceService  } from './hub-conn-service.service';
import { BluetoothCore } from '@manekinekko/angular-web-bluetooth';

@Component({
  selector: 'app-hub-searcher',
  templateUrl: './hub-searcher.component.html',
  styleUrls: ['./hub-searcher.component.scss']
})
export class HubSearcherComponent implements OnInit {
  ssid : string = ""
  passphrase : string = ""
  device: any = {};
  
  constructor( public _zone: NgZone,
    public _hubConnService: HubConnServiceService) { }

  ngOnInit(): void {
    this.getDeviceStatus();
  }
  //Show battery level
  connected(value: any){
    //value.addEventListener("characteristicvaluechanged", (this, this.yeet), false)
    // BluetoothRemoteGATTCharacteristic
    console.log("Status: " + value);
    // value.addEventListener("characteristicvaluechanged", this.yeet);
  }

  yeet(event : any){
    console.log("yeet called");
    console.log(event.target.value);
  }
  //get batterly lavel, user click
  connect(){
    this._hubConnService?.getCharConnect()?.subscribe(this.connected.bind(this));
  }

  getDeviceStatus() {
    this._hubConnService.getDevice().subscribe((device) => {
      if (device) {
        this.device = device;
        // device.oncharacteristicvaluechanged
      } else {
        // device not connected or disconnected
        this.device = null;
      }
    });
  }

  async sendinput(){
    const encoder = new TextEncoder();
    // json convert to ssid and password
    var obj:any = {}
    obj.ID = 0;
    obj.SSID = this.ssid;
    obj.PassPhrase = this.passphrase;

    var jStr = JSON.stringify(obj);
    let encodedString = encoder.encode(jStr);
    console.log('writing to character json: ' + jStr);
    console.log('writing to character json: ' + encodedString);

   // Try with response, but after it changes the ip
    await this._hubConnService.getCharacter().writeValueWithoutResponse(encodedString);
  }

  onSsidKey(event: any) { // without type info
    this.ssid = event.target.value;
  }
  onPassPhraseKey(event: any) { // without type info
    this.passphrase = event.target.value;
  }
}
