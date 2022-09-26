import { TestBed } from '@angular/core/testing';

import { SocketDeviceService } from './socket-device.service';

describe('SocketDeviceService', () => {
  let service: SocketDeviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SocketDeviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
