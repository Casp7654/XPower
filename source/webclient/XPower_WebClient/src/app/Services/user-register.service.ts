import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../Models/User';
import { UserToken } from '../Models/UserToken'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  // Create user
  createUser(user : User) : Observable<UserToken> {
    return this.http.post<UserToken>(environment.apiServer.url+"api/user/CreateUser",  user)
  }

  saveCreatedUser(createdUser : UserToken){
    // save user token in local storage
    localStorage.setItem("xpowerToken", createdUser.token);
      
    // save user in local storage
    localStorage.setItem("xpowerUser", JSON.stringify({ createdUser }))
  }
}
