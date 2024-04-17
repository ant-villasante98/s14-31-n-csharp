import { Component, ElementRef, OnInit, ViewChild, inject, input, signal } from '@angular/core';
import { QrService } from './services/qr.service';
import { HtmlParser } from '@angular/compiler';
import { Router } from '@angular/router';
import { AuthService } from '../auth/services/auth.service';
import { JsonPipe, NgClass } from '@angular/common';
import { AuthManagerService } from '../../shared/services/auth-manager.service';
import { UserLogin } from '../../models/user-login';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CardShopComponent } from '../search/components/card-shop/card-shop.component';
import { SearchModalComponent } from './modals/search-modal/search-modal.component';

@Component({
  selector: 'app-test',
  standalone: true,
  imports: [NgClass, ReactiveFormsModule, JsonPipe, SearchModalComponent, CardShopComponent],
  templateUrl: './test.component.html',
  styleUrl: './test.component.css'
})
export class TestComponent implements OnInit {
  ngOnInit(): void {
  }

  showSearchModal = signal<boolean>(true)


  tooltipState = signal(false);

  private _qrService = inject(QrService)

  svgElement: string = ""

  @ViewChild("svgContent", { static: false }) svgContent!: ElementRef<HTMLElement>

  private _authService = inject(AuthService)
  private router = inject(Router)
  private autManager = inject(AuthManagerService)

  submitState = signal<boolean>(true)



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


}
