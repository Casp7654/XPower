import { HttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { AuthguardService } from './authguard.service';

describe('AuthguardService', () => {
  let service: AuthguardService;

  let mockHttp = jasmine.createSpyObj('HttpClient', ['post', 'get']);

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [{ provide: HttpClient, useValue: mockHttp }]
    });
    service = TestBed.inject(AuthguardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
