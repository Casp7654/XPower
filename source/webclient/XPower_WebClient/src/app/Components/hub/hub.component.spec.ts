import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HubDevice } from 'src/app/Models/HubDevice';

import { HubComponent } from './hub.component';


describe('HubComponent', () => {
  let component: HubComponent;
  const expectedDevice = {
    name: "Hub 1",
    mac: "macAddr"
  };
  let fixture: ComponentFixture<HubComponent>;
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HubComponent ]
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

  it('should display have opacity class when status is false', () => {
    component.device.status = false;
    expect(component.device.status)
    .toBeFalse();

    fixture.detectChanges();

    const nativeElements: HTMLElement = fixture.nativeElement;
    let elements = nativeElements.getElementsByClassName('opacity');
    expect(elements.length)
    .toEqual(1);
  });

  it('should display name for hub', () => {

    component.device.name = expectedDevice.name;
    fixture.detectChanges();

    const nativeElements: HTMLElement = fixture.nativeElement;
    
    expect(nativeElements.textContent)
    .toContain(expectedDevice.name);
  });

  it('should display mac address for hub', () => {

    component.device.mac_address = expectedDevice.mac;
    fixture.detectChanges();
    const nativeElements: HTMLElement = fixture.nativeElement;

    expect(nativeElements.textContent)
    .toContain(expectedDevice.mac);
  });
});
