import { TestBed } from '@angular/core/testing';

import { HubConnServiceService } from './hub-conn-service.service';

describe('HubConnServiceService', () => {
  let service: HubConnServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HubConnServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
