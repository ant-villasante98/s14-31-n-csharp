import { Component, Input, WritableSignal, inject, OnInit, signal, computed, Signal } from '@angular/core';
import { MainModalComponent } from '../../../../shared/components/modals/main-modal/main-modal.component';
import { CardShoppingComponent } from '../card-shopping/card-shopping.component';
import { ItemCart, ShoppingCartManagerService } from '../../../services/shopping-cart-manager.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-shoppping-cart',
  standalone: true,
  imports: [MainModalComponent, CardShoppingComponent],
  templateUrl: './shoppping-cart.component.html',
  styleUrl: './shoppping-cart.component.css'
})
export class ShopppingCartComponent implements OnInit {
  @Input({ alias: "showModal", required: true }) showModal!: WritableSignal<boolean>;

  private router = inject(Router);

  private _cartManager = inject(ShoppingCartManagerService)

  cartContent: WritableSignal<ItemCart[]> = this._cartManager.cartContent

  total = this._cartManager.priceTotal

  constructor() {
  }

  ngOnInit(): void {
  }

  createOrder() {
    if (this.total() > 0) {
      this.router.navigateByUrl("/create-order")
      this.showModal.set(false)
    }
  }

}
