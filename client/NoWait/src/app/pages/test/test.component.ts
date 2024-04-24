import { Component, ElementRef, OnInit, ViewChild, inject, input, signal } from '@angular/core';
import { QrService } from './services/qr.service';
import { HtmlParser } from '@angular/compiler';
import { Router } from '@angular/router';
import { AuthService } from '../auth/services/auth.service';
import { JsonPipe, NgClass } from '@angular/common';
import { AuthManagerService } from '../../shared/services/auth-manager.service';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CardShopComponent } from '../search/components/card-shop/card-shop.component';
import { SearchModalComponent } from '../../shared/components/modals/search-modal/search-modal.component';
import { MainModalComponent } from '../../shared/components/modals/main-modal/main-modal.component';
import { ShopppingCartComponent } from '../../shared/components/modals/shoppping-cart/shoppping-cart.component';
import { ItemCart, ShoppingCartManagerService } from '../../shared/services/shopping-cart-manager.service';
import { FoodModalComponent } from '../../shared/components/modals/food-modal/food-modal.component';
import { Product } from '../../models/malls';
import { MsnErrorComponent } from '../../shared/components/msn-error/msn-error.component';
import { SignalrService } from './services/signalr.service';

@Component({
  selector: 'app-test',
  standalone: true,
  imports: [NgClass, JsonPipe],
  templateUrl: './test.component.html',
  styleUrl: './test.component.css'
})
export class TestComponent implements OnInit {
  ngOnInit(): void {
  }

  svgElement: string = ""

  @ViewChild("svgContent", { static: false }) svgContent!: ElementRef<HTMLElement>





  decodeHtml(html: string): string {
    let txt = document.createElement("textarea");
    txt.innerHTML = html;
    return txt.value;
  }

}
