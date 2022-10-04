import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserLogoutService {

  constructor() { }

  logoutUser():boolean {
    //localStorage.clear();
    localStorage.removeItem("xpowerToken");
    localStorage.removeItem("xpowerUser");
    return true;
  }
}
