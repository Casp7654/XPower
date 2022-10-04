import { TestBed } from '@angular/core/testing';
import { Subject } from 'rxjs';
import { IoTService } from './io-t.service';
import { MqttClientService } from './mqtt-client.service';

describe('IoTService', () => {
  let service: IoTService;

  let func: Subject<string> = new Subject<string>();
  let applicationData: string;
  let mockMqttService = {
    Subscribe(target: string, onMessageFunc: (message : string) => void) : void {
      func.subscribe((msg: string) => {
        onMessageFunc(msg);
      });
    },
    Publish(target: string, data: string) : void {
      func.next(applicationData);
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
  });

  it('Should return 0 devices when calling status', () => {
    applicationData = "[]";
    service.GetSocketDevicesFromHub("");

    expect(service.GetDevices().length).toEqual(0)
  });

  it('Should return 0 devices when calling status when applicationData is empty', () => {
    applicationData = "";
    service.GetSocketDevicesFromHub("");

    expect(service.GetDevices().length).toEqual(0)
  });


  it('Should return 1 devices when 2 with same id', () => {
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
        },
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
  });
});
