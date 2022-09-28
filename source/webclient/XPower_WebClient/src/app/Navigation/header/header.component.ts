import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  //Event emitter for side navigation opening
  @Output() public sidenavOpen = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  //Emits the sidenavOpen event when called.
  public onSidenavOpen(): void 
  {
    this.sidenavOpen.emit();
  };
}
