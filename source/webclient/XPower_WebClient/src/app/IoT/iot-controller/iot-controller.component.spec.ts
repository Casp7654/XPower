import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IotControllerComponent } from './iot-controller.component';

describe('IotControllerComponent', () => {
  let component: IotControllerComponent;
  let fixture: ComponentFixture<IotControllerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IotControllerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IotControllerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
