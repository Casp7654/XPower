import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { UserLogoutService } from 'src/app/Services/user-logout.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  //Event emitter for side navigation opening
  @Output() public sidenavOpen = new EventEmitter();

  constructor(private logoutservice: UserLogoutService, private router: Router) { }

  ngOnInit(): void {
  }

  //Emits the sidenavOpen event when called.
  public onSidenavOpen(): void
  {
    this.sidenavOpen.emit();
  };

  // Remove localstorage token and user and move to default page
  public onLogout(): void {
    this.logoutservice.logoutUser();
    this.router.navigate([""]);
  }
}
