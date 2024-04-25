import { Component, Input, OnInit, WritableSignal, computed, inject, signal } from '@angular/core';
import { MainModalComponent } from '../main-modal/main-modal.component';
import { UpperCasePipe } from '@angular/common';
import { Product } from '../../../../models/malls';
import { ShoppingCartManagerService } from '../../../services/shopping-cart-manager.service';

@Component({
  selector: 'app-food-modal',
  standalone: true,
  imports: [MainModalComponent, UpperCasePipe],
  templateUrl: './food-modal.component.html',
  styleUrl: './food-modal.component.css'
})
export class FoodModalComponent implements OnInit {

  private _cartManageService = inject(ShoppingCartManagerService)

  element: Product | null = null;

  @Input({ required: true }) imgShop: string | null = '';
  @Input({ required: true }) shopName: string | null = '';
  @Input({ required: true }) shopLocal: string | null = '';

  @Input() set itemMenu(value: Product | null) {
    if (value) {
      console.log('nuevo elemento', value.name)
      this.element = value
      this.undPrice = this.element.price;
    }
  }

  @Input({ alias: "show-food", required: true }) showModal!: WritableSignal<boolean>


  count = signal<number>(0)

  undPrice = 0;

  total = computed<number>(() => {
    return Number((this.count() * this.undPrice).toFixed(2))
  })




  // private formBuilder = inject(FormBuilder)
  // formCount: FormGroup = new FormGroup({})
  // get amount() {
  //   return this.formCount.controls['amount']
  // }
  ngOnInit(): void {
    // this.formCount = this.formBuilder.group({
    //   amount: [0]
    // })
  }


  closeModal() {
    this.showModal.set(false)
    this.count.set(0)
  }

  add() {
    this.count.update(v => ++v)
  }

  subtract() {

    this.count.update(v => {
      if (v == 0) {
        return 0;
      }
      return --v;
    })
  }
  addItem() {
    if (this.element) {
      console.log(this.element)

      let { id, shopId, imageUrl, name, price, description } = this.element;
      this._cartManageService.updateItem({
        id,
        shopId,
        shopLocal: this.shopLocal ?? '',
        shopName: this.shopName ?? '',
        amount: this.count(),
        imgUrl: imageUrl,
        name,
        price,
        description
      })
    }
  }

  errorHandlerFood(event: Event) {
    let img = event.target
    if (img instanceof HTMLImageElement) {
      img.src = 'assets/error-img.jpg'
    }
  }

  errorHandlerLogo(event: Event) {
    let img = event.target
    if (img instanceof HTMLImageElement) {
      img.src = 'assets/Logo-Circulo.png'
    }

  }
}
