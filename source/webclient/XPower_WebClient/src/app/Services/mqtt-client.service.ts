import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IMqttMessage, MqttService } from 'ngx-mqtt';

@Injectable({
  providedIn: 'root'
})
export class MqttClientService {

  private brokerUrl: string;

  constructor(private client: MqttService) {
    this.brokerUrl = environment.brokerUrl;
    this.client.observe("test").subscribe((msg: IMqttMessage) => {
      console.log(msg.payload);
    });

    this.client.unsafePublish("test", "Hej med dig fra constructor");
  }

  Publish(target: string, data: string) {
    //this.client.publish(target, data);
  }
}
