import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Observable } from 'rxjs';
import { HubConnServiceService } from 'src/app/Services/hub-conn-service.service';
import { HubSearcherComponent } from './hub-searcher.component';

class mockBluetoothClass implements BluetoothDevice {
  id: string = "";
  name?: string | undefined;
  gatt?: BluetoothRemoteGATTServer | undefined;
  forget(): Promise<void> {
    throw new Error('Method not implemented.');
  }
  watchAdvertisements(options?: WatchAdvertisementsOptions | undefined): Promise<void> {
    throw new Error('Method not implemented.');
  }
  unwatchAdvertisements(): void {
    throw new Error('Method not implemented.');
  }
  watchingAdvertisements: boolean = true;
  addEventListener(type: 'gattserverdisconnected', listener: (this: this, ev: Event) => any, useCapture?: boolean | undefined): void;
  addEventListener(type: 'advertisementreceived', listener: (this: this, ev: BluetoothAdvertisingEvent) => any, useCapture?: boolean | undefined): void;
  addEventListener(type: string, listener: EventListenerOrEventListenerObject, useCapture?: boolean | undefined): void;
  addEventListener(type: unknown, listener: unknown, useCapture?: unknown): void {
    throw new Error('Method not implemented.');
  }
  dispatchEvent(event: Event): boolean {
    throw new Error('Method not implemented.');
  }
  removeEventListener(type: string, callback: EventListenerOrEventListenerObject | null, options?: boolean | EventListenerOptions | undefined): void {
    throw new Error('Method not implemented.');
  }
  removeAllListeners?(eventName?: string | undefined): void {
    throw new Error('Method not implemented.');
  }
  eventListeners?(eventName?: string | undefined): EventListenerOrEventListenerObject[] {
    throw new Error('Method not implemented.');
  }
  onadvertisementreceived: (this: this, ev: BluetoothAdvertisingEvent) => undefined = () => {return undefined;};
  ongattserverdisconnected: (this: this, ev: Event) => any = () => {return undefined;};
  oncharacteristicvaluechanged: (this: this, ev: Event) => any = () => {return undefined;};
  onserviceadded: (this: this, ev: Event) => any = () => {return undefined;};
  onservicechanged: (this: this, ev: Event) => any = () => {return undefined;};
  onserviceremoved: (this: this, ev: Event) => any = () => {return undefined;};

}

describe('HubSearcherComponent', () => {
  let component: HubSearcherComponent;
  let fixture: ComponentFixture<HubSearcherComponent>;
  let connServiceMock: HubConnServiceService;
  let formBuilderMock;

  beforeEach(async () => {
    //connServiceMock = jasmine.createSpyObj(['getDevice', 'getCharConnect', 'getCharacter']);
    const fakeDevice = new Observable<BluetoothDevice>((obs) => {
      obs.next(new mockBluetoothClass());
      obs.complete();
    });

    connServiceMock = jasmine.createSpyObj('HubConnServiceService', {
      'getDevice': fakeDevice,
      'getCharConnect': new Observable<number>(obs => obs.next(1))
    });
    formBuilderMock = new FormBuilder();

    await TestBed.configureTestingModule({
      declarations: [ HubSearcherComponent ],
      imports: [ReactiveFormsModule, 
        MatFormFieldModule,
        MatInputModule,
        MatIconModule,
        BrowserAnimationsModule],
      providers: [{provide: HubConnServiceService, useValue: connServiceMock}, {provide: FormBuilder, useValue: formBuilderMock} ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HubSearcherComponent);
    component = fixture.componentInstance;
    component.credentials = formBuilderMock.group({hideRequired: false,
      floatLabel: 'auto',
      apariencia: 'fill',
      fbssid : '',
      fbpassphrase : ''});

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
