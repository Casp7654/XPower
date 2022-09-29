import { NgModule } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatGridList, MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { HubDevice } from 'src/app/Models/HubDevice';

import { HubComponent } from './hub.component';

describe('HubComponent', () => {
  let component: HubComponent;
  let fixture: ComponentFixture<HubComponent>;
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HubComponent ],
      imports: [ MatGridListModule,
        MatFormFieldModule,
        MatInputModule,
        MatGridListModule,
        MatToolbarModule,
        MatIconModule,
        MatCardModule,
        MatDividerModule,
        MatSidenavModule,
        MatButtonModule,
        MatListModule ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HubComponent);
    component = fixture.componentInstance;
    component.device = new HubDevice();
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
