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

  formLogin: FormGroup = new FormGroup({});

  constructor(
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.formLogin = this.formBuilder.group({
      email: ["", Validators.compose([Validators.required, Validators.email])],
      password: ["", Validators.compose([Validators.required, Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$/)])]
    })

    this.autManager.getCredentials();
  }

  submitLogin(): void {
    this.submitState.set(false);
    
    if (this.formLogin.invalid)
    {
      this.submitState.set(true);          
      return;
    }

    console.log("Realizando peticion")
    let userlogin: UserLogin = this.formLogin.value as UserLogin;
    this._authService.login(userlogin)
      .subscribe({
        next: (data) => {
          this.router.navigateByUrl("/");
        },
        error: (errors: any) => {
          this.submitState.set(true)
        },
        complete: () => {
          this.submitState.set(true);          
        }
      })
  }
}
