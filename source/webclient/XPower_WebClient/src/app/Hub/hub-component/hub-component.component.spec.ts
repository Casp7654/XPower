import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HubComponentComponent } from './hub-component.component';

describe('HubComponentComponent', () => {
  let component: HubComponentComponent;
  let fixture: ComponentFixture<HubComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HubComponentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HubComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
