import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { HubDevice } from 'src/app/Models/HubDevice';

import { HubComponent } from './hub.component';

describe('HubComponent', () => {
  let component: HubComponent;
  let fixture: ComponentFixture<HubComponent>;
  let expectedDevice = new HubDevice();


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
    component.device = expectedDevice;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have device name rendered', () => {

    const nativeElements: HTMLElement = fixture.nativeElement;

    expect(nativeElements.textContent)
    .toContain(expectedDevice.name);
  });

  it('should have device mac rendered', () => {

    const nativeElements: HTMLElement = fixture.nativeElement;

    expect(nativeElements.textContent)
    .toContain(expectedDevice.mac_address);
  });
});
