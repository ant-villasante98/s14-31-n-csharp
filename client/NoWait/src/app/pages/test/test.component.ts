import { Component, ElementRef, OnInit, ViewChild, inject, input } from '@angular/core';
import { AuthService } from '../login/services/auth.service';
import { QrService } from './services/qr.service';
import { HtmlParser } from '@angular/compiler';
import { Router } from '@angular/router';

@Component({
  selector: 'app-test',
  standalone: true,
  imports: [],
  templateUrl: './test.component.html',
  styleUrl: './test.component.css'
})
export class TestComponent implements OnInit {

  private _authService = inject(AuthService)

  private _qrService = inject(QrService)

  svgElement: string = ""

  private router = inject(Router)

  @ViewChild("svgContent", { static: false }) svgContent!: ElementRef<HTMLElement>

  ngOnInit(): void {

    // optener el svg de la response
    // this._qrService.getSVGEncoden(126)
    //   .subscribe({
    //     next: (res: any) => {

    //       this.svgElement = this.decodeHtml(res.svgValue);
    //       this.svgContent.nativeElement.innerHTML = this.svgElement;
    //     }
    //   })
    this._qrService.test().subscribe()
  }

  decodeHtml(html: string): string {
    let txt = document.createElement("textarea");
    txt.innerHTML = html;
    return txt.value;
  }

  submitlogin() {
    this._authService.login({ email: "antonio@email.com", password: "Password1!" })
      .subscribe({
        next: (data) => {
          this.router.navigateByUrl("/");
        }
      })
  }

  getAuthUser() {
    let res = JSON.parse(localStorage.getItem("value") ?? "")
    console.log("-- resultado");
    console.log(res)
  }
}
