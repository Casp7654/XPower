import { TestBed } from '@angular/core/testing';
import { BluetoothCore } from '@manekinekko/angular-web-bluetooth';

import { HubConnServiceService } from './hub-conn-service.service';

describe('HubConnServiceService', () => {
  let service: HubConnServiceService;
  let bluetoothMockService;

  beforeEach(() => {
    bluetoothMockService = jasmine.createSpyObj(['discover$', 'pipe', 'getPrimaryService$', 'getCharacteristic$', 'getDevice$', 'streamValues$', 'readValue$']);
    TestBed.configureTestingModule({
      providers: [{provide: BluetoothCore, useValue: bluetoothMockService}]
    });
    service = TestBed.inject(HubConnServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
