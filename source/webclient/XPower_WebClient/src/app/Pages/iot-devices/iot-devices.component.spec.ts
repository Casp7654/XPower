import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { IoTService } from 'src/app/Services/io-t.service';
import { SocketDeviceService } from 'src/app/Services/socket-device.service';
import { IotDevicesComponent } from './iot-devices.component';

describe('IotDevicesComponent', () => {
  let component: IotDevicesComponent;
  let fixture: ComponentFixture<IotDevicesComponent>;
  let mockIoTService;
  let mockSocketDeviceService;

  beforeEach(async () => {

    mockIoTService = jasmine.createSpyObj(['GetSocketDevicesFromHub', 'GetFilteredDevices']);

    mockSocketDeviceService = jasmine.createSpyObj(['TurnOff']);

    await TestBed.configureTestingModule({
      declarations: [ IotDevicesComponent ],
      imports: [MatGridListModule, MatIconModule],
      providers: [{provide: IoTService, useValue: mockIoTService},
      {provide: SocketDeviceService, useValue: mockSocketDeviceService}]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IotDevicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
