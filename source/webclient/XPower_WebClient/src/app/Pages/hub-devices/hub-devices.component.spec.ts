import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { HubComponent } from 'src/app/Components/hub/hub.component';

import { HubDevicesComponent } from './hub-devices.component';

describe('HubDevicesComponent', () => {
  let component: HubDevicesComponent;
  let fixture: ComponentFixture<HubDevicesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HubDevicesComponent, HubComponent ],
      imports: [
        MatGridListModule,
        MatIconModule,
        MatCardModule,
        MatListModule
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HubDevicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
