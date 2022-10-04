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

  ValidateLoginUser(userLogin: UserLogin) {
    return this.http.post<UserLogin>(`${environment.apiServer.url}api/user/Login`,userLogin);
  }
}
