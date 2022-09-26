import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MqttClientService {

  private client: string;
  private brokerUrl: string;

  constructor() {
    this.brokerUrl = environment.brokerUrl;
    this.client = ""
  }

  Publish(target: string, data: string) {
    //this.client.publish(target, data);
  }
}
