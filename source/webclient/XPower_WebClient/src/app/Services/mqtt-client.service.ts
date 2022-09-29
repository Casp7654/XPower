import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IMqttMessage, MqttService, IMqttServiceOptions } from 'ngx-mqtt';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MqttClientService {

  private client: MqttService;

  constructor() {
    this.client = new MqttService(this.CreateOptions());
  }
  
  /*
  Publishes data to the broker, target is the topic and data is the payload
  */
  Publish(target: string, data: string) : void {
    this.client.unsafePublish(target, data);
  }

  /*
  Subscribes to a topic and attaches a event function for when a message
  with that specific topic is catched.
  */
  Subscribe(target: string, onMessageFunc: (message : string) => void) : void {
    this.client.observe(target).subscribe((msg: IMqttMessage) => {
      onMessageFunc(new TextDecoder().decode(msg.payload));
    });
  }

  /*
  Creates the connection options for the client.
  */
  private CreateOptions() : IMqttServiceOptions {
    let settings = environment.mqttClientSettings;
    return {
      hostname: settings.url,
      port: settings.port,
      path: settings.path
    };
  }
}
