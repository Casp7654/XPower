import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Observable } from 'rxjs';
import { User } from '../Models/User';
import { UserToken } from '../Models/UserToken';

import { UserService } from './user-register.service';

describe('UserService', () => {
  let service: UserService;
  let expectedUser : User = new User("a","b","c","d","e");
  let expectedUserToken = new Observable<UserToken>(x => x.next(new UserToken("a","b","c","d","e", "ey")));
  let httpClientSpyPost = jasmine.createSpyObj('HttpClient', ['post']);
  let registerUserService = new UserService(<any>httpClientSpyPost);
  let localStore;

  beforeEach(() => {
    TestBed.configureTestingModule({imports: [HttpClientTestingModule]});
    service = TestBed.inject(UserService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should create token', () => {
    let createdObject;
    let mockTokenObject;
    httpClientSpyPost.post.and.returnValue(expectedUserToken)

    registerUserService.createUser(expectedUser).subscribe(x => {  createdObject = x });
    expectedUserToken.subscribe(x => {  mockTokenObject = x });
   
    expect(createdObject).toEqual(mockTokenObject);
  });
});

