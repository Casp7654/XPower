import { computeMsgId, publishFacade } from '@angular/compiler';
import { TestBed } from '@angular/core/testing';
import { IoTService } from './io-t.service';
import { MqttClientService } from './mqtt-client.service';

describe('IoTService', () => {
  let service: IoTService;

  let func: (msg: string) => void;
  let applicationData: string;
  let mockMqttService = {
    Subscribe(target: string, onMessageFunc: (message : string) => void) : void {
      func = onMessageFunc;
    },
    Publish(target: string, data: string) : void {
      func(applicationData);
    }
  };

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [{provide: MqttClientService, useValue: mockMqttService}]
    });
    service = TestBed.inject(IoTService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('Should return 1 device when calling status', () => {
    applicationData = JSON.stringify(
    [
      {
        "Device": {
          "ClientId": "device5",
          "StatusId": 3,
          "TypeId": 1,
          "MacAdress": "8ac91bbd-1143-45f9-bd2e-ab4037d50b0f"
        },
        "Data": {
          "TurnedOn": false
        }
      }
    ]);
    service.GetSocketDevicesFromHub("");

    expect(service.GetDevices().length).toEqual(1)
  })
});
