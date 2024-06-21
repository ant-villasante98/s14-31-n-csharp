import { Injectable, Signal, WritableSignal, computed, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartManagerService {

  private storageName = 'shopping-cart';

  readonly cartContent: WritableSignal<ItemCart[]>;

  readonly itemsCount: Signal<number>;

  readonly priceTotal: WritableSignal<number> = signal(0);

  constructor() {
    this.cartContent = signal(this.getStorageCart());
    this.itemsCount = computed(() => {
      console.log(this.cartContent());
      return this.cartContent().length
    })
    this.updatePriceTotal()

  }

  updatePriceTotal() {
    let countTotal = 0
    for (let item of this.cartContent()) {
      countTotal += item.amount * item.price;

    }
    this.priceTotal.set(Number((countTotal).toFixed(2)))
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
    this.updatePriceTotal()
  }


  // manejo del signal

  GetItem(itemId: number): ItemCart | null {
    let index = this.cartContent().findIndex(v => v.id == itemId);
    if (index != -1) {
      return this.cartContent()[index];
    }
    return null
  }

  updateItem(item: ItemCart) {
    let cloneItem = { ...item }
    if (cloneItem.amount <= 0) {
      this.removeItem(item.id);
      return
    }
    this.cartContent.update((value) => {
      let index = value.findIndex(v => v.id == cloneItem.id)
      if (index != -1) {
        value[index].amount = cloneItem.amount
        return value;
      }
      value.push(cloneItem);
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

  increaseItem(cartIndex: number) {
    this.cartContent.update(value => {
      ++value[cartIndex].amount
      return value
    })
    this.updateStorage(this.cartContent())
  }

  decreaseItem(cartIndex: number) {
    this.cartContent.update(value => {
      --value[cartIndex].amount
      if (value[cartIndex].amount <= 0) {
        value.splice(cartIndex, 1);
      }
      return value
    })
    this.updateStorage(this.cartContent())
  }


  // Validacion de Items de carrito
  validateItems(value: any): ItemCart[] {
    if (!Array.isArray(value)) {
      return []
    }
    let itemArray = value as ItemCart[]
    for (let e of value) {

      if (e == null || e.id == undefined || e.name == undefined || e.price == undefined || e.amount == undefined || e.imgUrl == undefined || e.shopId == undefined) {
        return []
      }
    };
    return itemArray;
  }
}

export interface ItemCart {
  id: number;
  shopId: number;
  shopName: string;
  shopLocal: string;
  name: string;
  price: number;
  amount: number;
  imgUrl: string;
  description: string;
}
