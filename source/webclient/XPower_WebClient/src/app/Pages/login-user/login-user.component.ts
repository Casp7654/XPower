import { Component, OnInit, ViewChild } from '@angular/core';
import { UserLoginService  } from 'src/app/Services/user-login.service';
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

  constructor(private router: Router, public userService : UserLoginService, fb: FormBuilder){
    this.credentials = fb.group({
      hideRequired: false,
      floatLabel: 'auto',
      apariencia: 'fill',
      username: '',
      password: '',
    });
  }

  onSubmit(){
    const user = this.formToLoginUser();

    //Validate user
    this.userService.ValidateLoginUser(user);

    //Refresh site
    this.router.navigate([""]);
  }

  formToLoginUser(): UserLogin
  {
    return new UserLogin(
      this.credentials.value.username,
      this.credentials.value.password
    )
  }

  ngOnInit(): void {}

}
