import { HttpClient } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { LoginUserComponent } from './login-user.component';

describe('LoginUserComponent', () => {
  let component: LoginUserComponent;
  let fixture: ComponentFixture<LoginUserComponent>;

  let mockHttp = jasmine.createSpyObj('HttpClient', ['post', 'get']);
  let mockFormBuilder = new FormBuilder();
  
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoginUserComponent ],
      providers: [
        { provide: HttpClient, useValue: mockHttp },
        { provide: FormBuilder, useValue: mockFormBuilder }
      ],
      imports: [ReactiveFormsModule, 
        MatFormFieldModule,
        MatInputModule,
        MatIconModule,
        BrowserAnimationsModule],
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoginUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
