import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-sidenav-list',
  templateUrl: './sidenav-list.component.html',
  styleUrls: ['./sidenav-list.component.scss']
})
export class SidenavListComponent implements OnInit {

  //Event emitter for side navigation closing
  @Output() public sidenavClose = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  //Emits the sidenavClose event when called.
  public onSidenavClose() : void {
    this.sidenavClose.emit();
  }

}
