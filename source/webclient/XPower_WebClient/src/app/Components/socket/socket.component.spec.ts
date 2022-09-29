import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { HubDevice } from 'src/app/Models/HubDevice';
import { SocketDevice } from 'src/app/Models/SocketDevice';

import { SocketComponent } from './socket.component';

const expectedDevice = {
  name: "nametest",
  group: "grouptest",
  mac: "mac",
  parentName: "Hub1"
};

describe('SocketComponent', () => {
  let component: SocketComponent;
  let fixture: ComponentFixture<SocketComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SocketComponent ],
      imports: [MatCardModule, MatDividerModule, MatIconModule]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SocketComponent);
    component = fixture.componentInstance;
    component.device = new SocketDevice(expectedDevice.name,
      true, 
      expectedDevice.mac, 
      true, 
      expectedDevice.group, 
      new HubDevice()
    );
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have online class when turned_on is true', () => {
    expect(component.device.turned_on)
    .toBeTrue();

    fixture.detectChanges();

    const nativeElements: HTMLElement = fixture.nativeElement;
    let elements = nativeElements.getElementsByClassName('online');
    expect(elements.length)
    .toEqual(1);
  });

  it('should display have offline class when turned_on is false', () => {
    component.device.turned_on = false;
    expect(component.device.turned_on)
    .toBeFalse();

    fixture.detectChanges();

    const nativeElements: HTMLElement = fixture.nativeElement;
    let elements = nativeElements.getElementsByClassName('offline');
    expect(elements.length)
    .toEqual(1);
  });

  it('should display name for device', () => {
    const nativeElements: HTMLElement = fixture.nativeElement;

    expect(nativeElements.textContent)
    .toContain(expectedDevice.name);
  });

  it('should display group for device', () => {
    const nativeElements: HTMLElement = fixture.nativeElement;

    expect(nativeElements.textContent)
    .toContain(expectedDevice.group);
  });

  it('should parent name for device', () => {
    const nativeElements: HTMLElement = fixture.nativeElement;

    expect(nativeElements.textContent)
    .toContain(expectedDevice.parentName);
  });
  
});
