import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatGridList, MatGridTile } from '@angular/material/grid-list';
import { MatIcon, MatIconModule } from '@angular/material/icon';
import { MatNavList } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbar } from '@angular/material/toolbar';
import { IotComponent } from '../iot/iot.component';
import { IotModule } from '../iot/iot.module';

import { IotControllerComponent } from './iot-controller.component';

describe('IotControllerComponent', () => {
  let component: IotControllerComponent;
  let fixture: ComponentFixture<IotControllerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IotControllerComponent, IotComponent, MatIcon, MatGridList, MatGridTile, MatToolbar],
      imports: []
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
