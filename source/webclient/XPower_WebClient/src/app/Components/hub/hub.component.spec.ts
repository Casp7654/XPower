import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { HubDevice } from 'src/app/Models/HubDevice';

import { HubComponent } from './hub.component';

describe('HubComponent', () => {
  let component: HubComponent;
  let fixture: ComponentFixture<HubComponent>;
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HubComponent ],
      imports: [
        MatIconModule,
        MatCardModule,
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
