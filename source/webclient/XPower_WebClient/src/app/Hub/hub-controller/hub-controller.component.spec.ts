import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatGridListModule } from '@angular/material/grid-list';
import { HubModule } from '../hub/hub.module';

import { HubControllerComponent } from './hub-controller.component';

describe('HubControllerComponent', () => {
  let component: HubControllerComponent;
  let fixture: ComponentFixture<HubControllerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HubControllerComponent ],
      imports: [MatGridListModule]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HubControllerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
