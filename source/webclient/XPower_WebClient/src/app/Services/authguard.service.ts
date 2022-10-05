import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { finalize } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthguardService implements CanActivate {

  constructor(private http: HttpClient) { }

  canActivate(): boolean {
    if (!this.hasToken()) {
      return false;
    }

    let token:string = localStorage.getItem("Token")!;
    let response = this.http.post<string>(`${environment.apiServer.url}api/user/ValidateToken?token=${token}`,token);

    response.pipe(finalize(()=> {
        console.log('complete');
    }));
    return true;
  }

  hasToken() {
    return (localStorage.getItem("Token") !== null) ? true : false;
  }
}
