import { Injectable } from '@angular/core';
import { SocketDeviceJsonRequestConverter } from '../Converters/Json/SocketDeviceJsonRequestConverter';
import { SocketDeviceRequestConverter } from '../Converters/SocketDeviceRequestConverter';
import { MqttClientService } from './mqtt-client.service';

@Injectable({
  providedIn: 'root'
})
export class SocketDeviceService {

  private requestConverter: SocketDeviceRequestConverter;

  constructor(private mqttService: MqttClientService) 
  { 
    this.requestConverter = new SocketDeviceJsonRequestConverter();
  }

  /*
  Sends a message to the target, that it should turn off.
  */
  TurnOff(target: string) {
    let topicTarget = "Led/" + target;
    let data = this.requestConverter.TurnOff();
    this.mqttService.Publish(topicTarget, data);
  }

  /*
  Sends a message to the target, that it should turn on.
  */
  TurnOn(target: string) {
    let topicTarget = "Led/" + target;
    let data = this.requestConverter.TurnOn();
    this.mqttService.Publish(topicTarget, data);
  }
}
