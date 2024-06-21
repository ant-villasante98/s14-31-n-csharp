import { Component, Input, computed, inject, signal } from '@angular/core';
import { ItemCart, ShoppingCartManagerService } from '../../../services/shopping-cart-manager.service';

@Component({
  selector: 'app-card-shopping',
  standalone: true,
  imports: [],
  templateUrl: './card-shopping.component.html',
  styleUrl: './card-shopping.component.css'
})
export class CardShoppingComponent {
  private _cartManager = inject(ShoppingCartManagerService)


  count = signal<number>(0)
  total = computed<number>(() => {
    return Number((this.count() * this.itemCart.price).toFixed(2))
  })
  itemCart!: ItemCart;


  @Input({ alias: "item-cart", required: true }) set SetItem(value: ItemCart) {
    this.itemCart = value;
    this.count.set(this.itemCart.amount)
  }

  @Input() index!: number;

  constructor() { }

  deleteItem() {
    this._cartManager.removeItem(this.itemCart.id)
  }


  add() {
    this.count.update(v => ++v)
    this._cartManager.updateItem(
      { ...this.itemCart, amount: this.count() }
    )
  }

  subtract() {

    this.count.update(v => {
      if (v == 0) {
        return 0;
      }
      return --v;
    })
    this._cartManager.updateItem(
      { ...this.itemCart, amount: this.count() }
    )
  }
}
