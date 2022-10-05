import { HttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { UserLoginService } from './user-login.service';

describe('UserLoginService', () => {
  let service: UserLoginService;

  let mockHttp = jasmine.createSpyObj('HttpClient', ['post', 'get']);

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [{ provide: HttpClient, useValue: mockHttp }]
    });
    service = TestBed.inject(UserLoginService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
