import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HubSearcherComponent } from './hub-searcher.component';

describe('HubSearcherComponent', () => {
  let component: HubSearcherComponent;
  let fixture: ComponentFixture<HubSearcherComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HubSearcherComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HubSearcherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
