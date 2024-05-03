import { Component, inject, signal } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { AuthManagerService } from '../../../../shared/services/auth-manager.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { UserLogin } from '../../../../models/user-login';
import { MsnErrorComponent } from '../../../../shared/components/msn-error/msn-error.component';

@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [MsnErrorComponent, ReactiveFormsModule],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.css'
})
export class SignUpComponent {

  private _authService = inject(AuthService)
  private router = inject(Router)
  private autManager = inject(AuthManagerService)

  submitState = signal<boolean>(true)

  showSpinnerSignUp = signal<boolean>(false)

  showBadRequest = signal<boolean>(false)

  formSignUp: FormGroup = new FormGroup({});

  private formBuilder: FormBuilder = inject(FormBuilder);
  constructor(
  ) { }

  ngOnInit(): void {
    this.formSignUp = this.formBuilder.group({
      email: ["", Validators.compose([Validators.required, Validators.pattern(/^[^\s@]+@[^\s@]+\.[^\s@]+$/)])],
      password: ["", Validators.compose([Validators.required, Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()\-_=+{};:,<.>]).*$/), Validators.minLength(6)])]
    })

    this.autManager.getCredentials();
  }

  get email() {
    return this.formSignUp.controls['email'];
  }
  get password() {
    return this.formSignUp.controls['password'];
  }

  submitSignUp(): void {
    this.formSignUp.disable()
    this.formSignUp.markAllAsTouched()

    this.formSignUp.enable()
    // TODO: mejorar logica

    if (this.formSignUp.invalid) {
      return;
    }

    this.showBadRequest.set(false)

    console.log("Realizando peticion")
    this.showSpinnerSignUp.set(true);
    let userlogin: UserLogin = this.formSignUp.value as UserLogin;
    this._authService.register(userlogin)
      .subscribe({
        next: (data) => {
          this.router.navigateByUrl('/auth/login');
        },
        error: (errors: any) => {
          this.showBadRequest.set(true)
          this.submitState.set(true)
          this.showSpinnerSignUp.set(false);

        },
        complete: () => {
          this.submitState.set(true);
          this.showSpinnerSignUp.set(false);
        }
      })
  }
}
