import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/Models/User';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { RegisterUserComponent } from './register-user.component';
import { By } from '@angular/platform-browser';
import { UserRegisterService } from 'src/app/Services/user-register.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { HttpClientTestingModule, HttpTestingController} from '@angular/common/http/testing';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';



describe('RegisterUserComponent', () => {
  let component: RegisterUserComponent;
  let fixture: ComponentFixture<RegisterUserComponent>;
  let expectedUser : User = new User("a","b","c","d","e");
  let formBuilderMock : FormBuilder;

  beforeEach(async () => {
      
    formBuilderMock = new FormBuilder();

    await TestBed.configureTestingModule({
      declarations: [ RegisterUserComponent ],
      imports: [
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatIconModule,
        BrowserAnimationsModule,
        HttpClientTestingModule
        ],
      providers: [{provide: FormBuilder, useValue: formBuilderMock}, {provide: UserRegisterService} ]
    }) 
    .compileComponents();

    fixture = TestBed.createComponent(RegisterUserComponent);
    component = fixture.componentInstance;
    
    component = fixture.componentInstance;
    component.credentials = formBuilderMock.group({
      hideRequired: false,
      floatLabel: 'auto',
      apariencia: 'fill',
      username : ['a', Validators.required],
      password : ['b', Validators.required],
      email : ['c', [Validators.required, Validators.pattern("^[^\s@]+@([^\s@.,]+\.)+[^\s@.,]{2,}$") ]], // regex pattern to check generic email adress
      firstname : ['d', Validators.required],
      lastname : ['e', Validators.required],
    });

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should return user', () => {
    component.credentials.controls["username"].setValue('a');
    component.credentials.controls["password"].setValue('b');
    component.credentials.controls["email"].setValue('c');
    component.credentials.controls["firstname"].setValue('d');
    component.credentials.controls["lastname"].setValue('e');
    expect(component.formToUser()).toEqual(expectedUser)
  });

  it('should not be valid email', () => {
    component.credentials.controls["email"].setValue('email.com');

   expect(component.credentials.controls["email"].valid).toBeFalse();
  })

  it('should not be valid when empty', () => {
    component.credentials.controls["username"].setValue('');
    component.credentials.controls["password"].setValue('');
    component.credentials.controls["email"].setValue('');
    component.credentials.controls["firstname"].setValue('');
    component.credentials.controls["lastname"].setValue('');
    expect(component.credentials.valid).toBeFalsy();
  });

  
  it('should call onSubmit method', () => {
    component.credentials.controls["username"].setValue('a');
    component.credentials.controls["password"].setValue('b');
    component.credentials.controls["email"].setValue('c@c.com');
    component.credentials.controls["firstname"].setValue('d');
    component.credentials.controls["lastname"].setValue('e');

    expect(component.credentials.valid).toBeTruthy()

    let createdUser : User = component.formToUser();

    expect(createdUser.username).toBe("a")
    expect(createdUser.password).toBe("b")
    expect(createdUser.email).toBe("c@c.com")
    expect(createdUser.firstName).toBe("d")
    expect(createdUser.lastName).toBe("e")
  });

  it('should have 5 inputs', () => {
    
    let inputs = fixture.debugElement.queryAll(By.css('input'));
    
    expect(inputs.length).toEqual(5);
  });

  it('should have submit button', () => {
    
    let input = fixture.debugElement.query(By.css('#submitBtn'));
    let native: HTMLElement = input.nativeElement;
    
    expect(input).not.toBeNull()
    expect(native.innerHTML).toContain("Opret bruger");
  }); 
});

