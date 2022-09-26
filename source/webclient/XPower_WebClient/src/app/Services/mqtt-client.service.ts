import { Injectable } from '@angular/core';
import * as mqtt from "mqtt"
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MqttClientService {

  private client: mqtt.MqttClient;
  private brokerUrl: string;

  constructor() {
    this.brokerUrl = environment.brokerUrl;
    this.client = mqtt.connect(this.brokerUrl);
  }
}
