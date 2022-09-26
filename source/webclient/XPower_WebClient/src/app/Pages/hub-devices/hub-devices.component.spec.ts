import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HubDevicesComponent } from './hub-devices.component';

describe('HubDevicesComponent', () => {
  let component: HubDevicesComponent;
  let fixture: ComponentFixture<HubDevicesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HubDevicesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HubDevicesComponent);
    component = fixture.componentInstance;
    component.iot = {id: "", name: ""};
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
