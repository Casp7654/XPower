import { Component, OnInit, ViewChild } from '@angular/core';
import { UserLoginService } from 'src/app/Services/user-login.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserLogin } from 'src/app/Models/UserLogin';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-user',
  templateUrl: './login-user.component.html',
  styleUrls: ['./login-user.component.scss']
})
export class LoginUserComponent implements OnInit {

  credentials: FormGroup;

  constructor(private router: Router, public userService: UserLoginService, fb: FormBuilder) {
    if (localStorage.getItem("Token") !== null) {
      this.router.navigate(["/home"])
    }
    this.credentials = fb.group({
      hideRequired: false,
      floatLabel: 'auto',
      apariencia: 'fill',
      username: '',
      password: '',
    });
  }

  onSubmit() {
    const user = this.formToLoginUser();

    //Validate user
    this.userService.ValidateLoginUser(user).subscribe((loggedinUser) => {
      //Save Token
      this.userService.saveLoggedinUser(loggedinUser);
      //Refresh site
      this.router.navigate(["/home"]);
    },
      (e) => alert("Forkert Brugernavn eller Password: " + e?.error?.message),
    );
  }

  onRegister() {
    this.router.navigate(["/register-user"]);
  }

  formToLoginUser(): UserLogin {
    return new UserLogin(
      this.credentials.value.username,
      this.credentials.value.password
    )
  }

  ngOnInit(): void { }

}
