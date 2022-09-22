import { Injectable } from '@angular/core';
import { BluetoothCore } from '@manekinekko/angular-web-bluetooth';
import { map, mergeMap, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HubConnServiceService {
  
  static GATT_CHARACTERISTIC_CONNECTION = '0000180d-0000-1000-8000-00805f9b34fb';
  static GATT_PRIMARY_SERVICE = '0000180f-0000-1000-8000-00805f9b34fb';
  chararacter : any = {}
  constructor(public ble: BluetoothCore) {
  }

  getCharConnect(){
    console.log('Getting Conn Service...');
    try {
      return this.chararacter = this.ble
        .discover$({
          acceptAllDevices: true,
          optionalServices: [HubConnServiceService.GATT_PRIMARY_SERVICE],
        }).pipe(
          mergeMap(gatt => {
            return this.ble.getPrimaryService$(
              (gatt as BluetoothRemoteGATTServer),
              HubConnServiceService.GATT_PRIMARY_SERVICE
            );
          })).pipe(
            mergeMap(primaryService => {
            return this.ble.getCharacteristic$(
              (primaryService as BluetoothRemoteGATTService),
              HubConnServiceService.GATT_CHARACTERISTIC_CONNECTION
            );
          }));
    } catch (e) {
      console.error('Oops! can not read value from %s');
    }  
    return null;
  }

  getCharacter() {
    return this.chararacter;
  }
  getDevice() {
    return this.ble.getDevice$();
  }
  streamValues() {
    return this.ble.streamValues$().pipe(map((value: DataView) => value.getUint8(0)))// map((value: DataView) => value.getUint8(0));
  }
}
