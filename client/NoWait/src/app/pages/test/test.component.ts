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

@Component({
  selector: 'app-test',
  standalone: true,
  imports: [NgClass, ReactiveFormsModule, JsonPipe, SearchModalComponent, CardShopComponent, ShopppingCartComponent, MainModalComponent, FoodModalComponent],
  templateUrl: './test.component.html',
  styleUrl: './test.component.css'
})
export class TestComponent implements OnInit {
  ngOnInit(): void {
  }

  showSearchModal = signal<boolean>(false)

  showCart = signal<boolean>(false)

  showFood = signal<boolean>(false);

  tooltipState = signal(false);

  private _qrService = inject(QrService)

  svgElement: string = ""

  @ViewChild("svgContent", { static: false }) svgContent!: ElementRef<HTMLElement>

  private _authService = inject(AuthService)
  private router = inject(Router)
  private autManager = inject(AuthManagerService)

  private _cartManager = inject(ShoppingCartManagerService)

  submitState = signal<boolean>(true)

  cart = this._cartManager.cartContent

  itemList = items;


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


  // testSearchFood(q: string) {
  //   this.router.navigate(['/search'], { queryParams: { q } })
  // }

  addItem(item: ItemCart) {
    this._cartManager.updateItem(item);

  }

  decreaseItem(index: number) {
    this._cartManager.decreaseItem(index);
  }
  increaseItem(index: number) {
    this._cartManager.increaseItem(index);
  }

  openFoodModa(value: Product) {
    this.product = value;
    this.showFood.set(true)
  }

  product: Product | null = null

  product1: Product = {
    id: 1000,
    shopId: 1,
    category: "Carnes",
    name: "Bife de Chorizo",
    description: "Corte de carne de vaca asado a la parrilla, jugoso y sabroso.",
    price: 28.99,
    imageUrl: "https://example.com/bife-de-chorizo.jpg",
    isAvailable: true
  }
  product2: Product = {
    id: 1001,
    shopId: 1,
    category: "Carnes",
    name: "Matambre a la Pizza",
    description: "Matambre de cerdo cocido a la parrilla y cubierto con salsa de tomate y queso derretido.",
    price: 22.5,
    imageUrl: "https://example.com/matambre-a-la-pizza.jpg",
    isAvailable: true
  }
}

export const items: ItemCart[] = [
  {
    id: 1,
    shopId: 1,
    amount: 3,
    imgUrl: "",
    name: 'burger',
    price: 3345.4,
    description: '',
  },
  {
    shopId: 1,
    description: '',
    id: 2,
    amount: 5,
    imgUrl: '',
    name: ' tallarin',
    price: 543.5
  },
  {
    id: 3,
    amount: 8,
    imgUrl: '',
    name: 'pizza',
    shopId: 1,
    description: '',
    price: 6245.3
  }
]

