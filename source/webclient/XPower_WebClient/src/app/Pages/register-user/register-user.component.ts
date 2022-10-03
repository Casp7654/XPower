import { Component, OnInit, ViewChild } from '@angular/core';
import { UserRegisterService  } from 'src/app/Services/user-register.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/Models/User';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.scss']
})
export class RegisterUserComponent implements OnInit {
  credentials: FormGroup;
  
  constructor(private router: Router, public userSerrvice : UserRegisterService, fb: FormBuilder)
  {
      this.credentials = fb.group({
        hideRequired: false,
        floatLabel: 'auto',
        apariencia: 'fill',
        username : '',
        password : '',
        email : ['', [Validators.required, Validators.pattern("^[^\s@]+@([^\s@.,]+\.)+[^\s@.,]{2,}$") ]], // regex pattern to check generic email adress
        firstname : '',
        lastname : '',
      });
    }

  onSubmit(){
    const user = this.formToUser();
    
    this.userSerrvice.createUser(user).subscribe(createdUser => {
      
      // Save user data
      this.userSerrvice.saveCreatedUser(createdUser);

      alert("Bruger oprettet")

      // Move back to main page
      this.router.navigate([""]);
    },
    e => {
      // Show error message to user
      alert("Kunne ikke oprette bruger: " + e?.error?.message);
    }
    )
  }

  formToUser() : User
  {
    return new User(
      this.credentials.value.username,
      this.credentials.value.password,
      this.credentials.value.email,
      this.credentials.value.firstname,
      this.credentials.value.lastname
    );
  }
  
  ngOnInit(): void {
  }

}
