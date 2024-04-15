import { Injectable, Signal, WritableSignal, computed, signal } from '@angular/core';
import { isEmpty } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartManagerService {

  private storageName = 'shopping-cart';

  readonly cartContent: WritableSignal<ItemCart[]>;

  readonly itemsCount: Signal<number>;

  constructor() {
    this.cartContent = signal(this.getStorageCart());
    this.itemsCount = computed(() => {
      console.log(this.cartContent());
      return this.cartContent().length
    })
  }

  // manejo de storage
  private getStorageCart(): ItemCart[] {
    console.log("/// Cargando valores al carrito")
    let storageContent = localStorage.getItem(this.storageName);
    if (!storageContent || storageContent == undefined) {
      return [];
    }
    let items = JSON.parse(storageContent)

    return this.validateItems(items);
  }


  updateStorage(value: ItemCart[]) {
    let valueString = JSON.stringify(value);

    localStorage.setItem(this.storageName, valueString);
  }


  // manejo del signal
  addItem(item: ItemCart) {
    this.cartContent.update((value) => {
      value.push(item);
      return value;
    });
    this.updateStorage(this.cartContent())
  }

  removeItem(itemId: number) {
    this.cartContent.update((value) => {
      let index = value.findIndex(i => i.id == itemId)
      if (index !== -1) {
        value.splice(index, 1);
      }
      return value
    })
    this.updateStorage(this.cartContent())
  }

  toEmptyCart() {
    this.cartContent.set([])
    this.updateStorage(this.cartContent())
  }


  // Validacion de Items de carrito
  validateItems(value: any): ItemCart[] {
    if (!Array.isArray(value)) {
      return []
    }
    let itemArray = value as ItemCart[]
    for (let e of value) {

      if (e == null || e.id == undefined || e.name == undefined || e.price == undefined || e.amount == undefined) {
        return []
      }
    };
    return itemArray;
  }
}

export interface ItemCart {
  id: number;
  name: string;
  price: number;
  amount: number
}
