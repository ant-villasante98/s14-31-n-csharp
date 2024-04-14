import { Component, OnInit, inject, signal } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { UserLogin } from '../../../../models/user-login';
import { AuthManagerService } from '../../../../shared/services/auth-manager.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

  private _authService = inject(AuthService)
  private router = inject(Router)
  private autManager = inject(AuthManagerService)

  submitState = signal<boolean>(true)

  showSpinnerLogin = signal<boolean>(false)

  showUnauthorization = signal<boolean>(false)

  formLogin: FormGroup = new FormGroup({});

  private formBuilder: FormBuilder = inject(FormBuilder);
  constructor(
  ) { }

  ngOnInit(): void {
    this.formLogin = this.formBuilder.group({
      email: ["", Validators.compose([Validators.required, Validators.email])],
      password: ["", Validators.compose([Validators.required, Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$/)])]
    })

    this.autManager.getCredentials();
  }

  get email() {
    return this.formLogin.controls['email'];
  }
  get password() {
    return this.formLogin.controls['password'];
  }

  submitLogin(): void {
    // TODO: mejorar logica
    this.submitState.set(false);

    if (this.formLogin.invalid) {
      this.submitState.set(true);
      return;
    }
    this.showUnauthorization.set(false)

    console.log("Realizando peticion")
    this.showSpinnerLogin.set(true);
    let userlogin: UserLogin = this.formLogin.value as UserLogin;
    this._authService.login(userlogin)
      .subscribe({
        next: (data) => {
          this.router.navigateByUrl("/");
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
