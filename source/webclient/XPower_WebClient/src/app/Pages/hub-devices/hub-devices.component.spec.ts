import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
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
