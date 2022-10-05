import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../Models/User';
import { UserLogin } from '../Models/UserLogin';
import { UserToken } from '../Models/UserToken'
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class UserLoginService {

  constructor(private http: HttpClient) { }

  // Login User
  ValidateLoginUser(userLogin: UserLogin): Observable<UserToken> {
    return this.http.post<UserToken>(`${environment.apiServer.url}api/user/Login`, userLogin);
  }

  // Save user Login and user in local storage
  saveLoggedinUser(loggedinUser: UserToken) {
    // save user login in local storage
    localStorage.setItem("Token", loggedinUser.token);
  }
}
