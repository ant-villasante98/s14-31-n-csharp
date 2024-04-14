import { Component, ElementRef, OnInit, ViewChild, inject, input, signal } from '@angular/core';
import { QrService } from './services/qr.service';
import { HtmlParser } from '@angular/compiler';
import { Router } from '@angular/router';
import { AuthService } from '../auth/services/auth.service';
import { JsonPipe, NgClass } from '@angular/common';
import { AuthManagerService } from '../../shared/services/auth-manager.service';
import { UserLogin } from '../../models/user-login';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-test',
  standalone: true,
  imports: [NgClass, ReactiveFormsModule, JsonPipe],
  templateUrl: './test.component.html',
  styleUrl: './test.component.css'
})
export class TestComponent implements OnInit {
  tooltipState = signal(false);

  private _qrService = inject(QrService)

  svgElement: string = ""

  @ViewChild("svgContent", { static: false }) svgContent!: ElementRef<HTMLElement>

  private _authService = inject(AuthService)
  private router = inject(Router)
  private autManager = inject(AuthManagerService)

  submitState = signal<boolean>(true)

  formLogin: FormGroup = new FormGroup({});
  private formBuilder: FormBuilder = inject(FormBuilder);

  // getters
  get email() {
    return this.formLogin.controls['email'];
  }
  get password() {
    return this.formLogin.controls['password'];
  }
  ngOnInit(): void {
    this.formLogin = this.formBuilder.group({
      email: ["", Validators.compose([Validators.required, Validators.email])],
      password: ["as", Validators.compose([Validators.required, Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$/)])]
    })

    this.email.untouched
    this.autManager.getCredentials();
    // optener el svg de la response
    // this._qrService.getSVGEncoden(126)
    //   .subscribe({
    //     next: (res: any) => {

    //       this.svgElement = this.decodeHtml(res.svgValue);
    //       this.svgContent.nativeElement.innerHTML = this.svgElement;
    //     }
    //   })
    // this._qrService.test().subscribe()
  }

  decodeHtml(html: string): string {
    let txt = document.createElement("textarea");
    txt.innerHTML = html;
    return txt.value;
  }


  getAuthUser() {
    let res = JSON.parse(localStorage.getItem("value") ?? "")
    console.log("-- resultado");
    console.log(res)
  }

  mostrar() {
    this.tooltipState.set(true)
    this.formLogin.valid
  }
  cerrar() {
    this.tooltipState.set(false)
  }


  submitLogin(): void {
    this.submitState.set(false);

    if (this.formLogin.invalid) {
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
