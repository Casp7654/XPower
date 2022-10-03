import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService  } from 'src/app/Services/user-register.service';
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
  
  constructor(private router: Router, public userSerrvice : UserService, fb: FormBuilder)
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
    const user = new User(
      this.credentials.value.username,
      this.credentials.value.password,
      this.credentials.value.email,
      this.credentials.value.firstname,
      this.credentials.value.lastname
    );
    
    this.userSerrvice.createUser(user).subscribe(createdUser => {
      
      alert("Bruger oprettet")

      // save user token in local storage
      localStorage.setItem("xpowerToken", createdUser.token);
      
      // save user in local storage
      localStorage.setItem("xpowerUser", JSON.stringify({ createdUser }))
      
      // move to default page
      this.router.navigate([""])
    },
    error => {
      // Show error message to user
      alert("Kunne ikke oprette bruger: " + error?.error?.message);
    }
    )
  }

  ngOnInit(): void {
  }

}
