import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserLogoutService {

  constructor() { }

  // Remove local storage data for that user
  logoutUser():boolean {
    localStorage.removeItem("Token");
    localStorage.removeItem("User");
    return true;
  }
}
