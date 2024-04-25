import { Component, OnInit, inject, signal } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { UserLogin } from '../../../../models/user-login';
import { AuthManagerService } from '../../../../shared/services/auth-manager.service';
import { JsonPipe } from '@angular/common';
import { MsnErrorComponent } from '../../../../shared/components/msn-error/msn-error.component';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, JsonPipe, MsnErrorComponent],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

  private _authService = inject(AuthService)
  private router = inject(Router)
  private autManager = inject(AuthManagerService)

  private urlNext: string = '/'
  submitState = signal<boolean>(true)

  showSpinnerLogin = signal<boolean>(false)

  showUnauthorization = signal<boolean>(false)

  formLogin: FormGroup = new FormGroup({});

  private formBuilder: FormBuilder = inject(FormBuilder);
  constructor(
  ) { }

  ngOnInit(): void {
    this.formLogin = this.formBuilder.group({
      email: ["", Validators.compose([Validators.required, Validators.pattern(/^[^\s@]+@[^\s@]+\.[^\s@]+$/)])],
      password: ["", Validators.compose([Validators.required, Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()\-_=+{};:,<.>]).*$/), Validators.minLength(6)])]
    })

    this.autManager.getCredentials();
    this.urlNext = window.history.state.url ?? "/"
    if (this.urlNext === '/user') {
      this.urlNext = '/'
    }
  }

  get email() {
    return this.formLogin.controls['email'];
  }
  get password() {
    return this.formLogin.controls['password'];
  }

  submitLogin(): void {
    this.formLogin.disable()
    this.formLogin.markAllAsTouched()

    this.formLogin.enable()
    // TODO: mejorar logica

    if (this.formLogin.invalid) {
      return;
    }

    this.showUnauthorization.set(false)

    console.log("Realizando peticion")
    this.showSpinnerLogin.set(true);
    let userlogin: UserLogin = this.formLogin.value as UserLogin;
    this._authService.login(userlogin)
      .subscribe({
        next: (data) => {
          this.router.navigateByUrl(this.urlNext);
        },
        error: (errors: any) => {
          this.showUnauthorization.set(true)
          this.submitState.set(true)
          this.showSpinnerLogin.set(false);

        },
        complete: () => {
          this.submitState.set(true);
          this.showSpinnerLogin.set(false);
        }
      })
  }
}
