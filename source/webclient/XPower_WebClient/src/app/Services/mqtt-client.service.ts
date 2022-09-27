import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IMqttMessage, MqttService, IMqttServiceOptions } from 'ngx-mqtt';

@Injectable({
  providedIn: 'root'
})
export class MqttClientService {

  private client: MqttService;

  constructor() {
    this.client = new MqttService(this.createOptions());

    this.client.observe("alabama").subscribe((msg: IMqttMessage) => {
      console.log(new TextDecoder().decode(msg.payload));
    });

    this.Publish("alabama", "hej med dig");
  }

  
  Publish(target: string, data: string) {
    this.client.unsafePublish(target, data);
  }

  private createOptions() : IMqttServiceOptions {
    let settings = environment.mqttClientSettings;
    return {
      hostname: settings.url,
      port: settings.port,
      path: settings.path
    };
  }
}
