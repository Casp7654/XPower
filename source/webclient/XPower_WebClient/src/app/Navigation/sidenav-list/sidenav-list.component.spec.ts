import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';

import { SidenavListComponent } from './sidenav-list.component';

describe('SidenavListComponent', () => {
  let component: SidenavListComponent;
  let fixture: ComponentFixture<SidenavListComponent>;
  let expectedName = {
    hubs: "Hubs",
    iot: "IoT Enheder",
    add: "Tilføj Hub"
  };

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SidenavListComponent],
      imports: [MatIconModule, MatListModule]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SidenavListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have hub menu rendered', () => {

    const nativeElements: HTMLElement = fixture.nativeElement;

    expect(nativeElements.textContent)
    .toContain(expectedName.hubs);
  });

  it('should have iot menu rendered', () => {

    const nativeElements: HTMLElement = fixture.nativeElement;

    expect(nativeElements.textContent)
    .toContain(expectedName.iot);
  });

  it('should have add menu rendered', () => {

    const nativeElements: HTMLElement = fixture.nativeElement;

    expect(nativeElements.textContent)
    .toContain(expectedName.add);
  });
});
