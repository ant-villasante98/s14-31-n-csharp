import { Component, Input, OnInit, WritableSignal, computed, inject, signal } from '@angular/core';
import { MainModalComponent } from '../main-modal/main-modal.component';
import { UpperCasePipe } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MallsService } from '../../../services/malls.service';
import { Product } from '../../../../models/malls';
import { ShoppingCartManagerService } from '../../../services/shopping-cart-manager.service';

@Component({
  selector: 'app-food-modal',
  standalone: true,
  imports: [MainModalComponent, UpperCasePipe, ReactiveFormsModule],
  templateUrl: './food-modal.component.html',
  styleUrl: './food-modal.component.css'
})
export class FoodModalComponent implements OnInit {

  private _cartManageService = inject(ShoppingCartManagerService)

  element: Product | null = null;

  @Input() set itemMenu(value: Product | null) {
    if (value) {
      this.element = value
      this.undPrice = this.element.price;
    }
  }

  @Input({ alias: "show-food", required: true }) showModal!: WritableSignal<boolean>


  count = signal<number>(0)

  undPrice = 0;

  total = computed<number>(() => {
    return this.count() * this.undPrice
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
    // this.amount.setValue(this.amount.value + 1)
    this.count.update(v => ++v)
  }

  subtract() {
    // if (this.amount.value == 0) {
    //   return
    // }
    // this.amount.setValue(this.amount.value - 1)


    this.count.update(v => {
      if (v == 0) {
        return 0;
      }
      return --v;
    })
  }
  addItem() {
    if (this.element) {

      let { id, shopId, imageUrl, name, price, description } = this.element;
      this._cartManageService.updateItem({
        id,
        shopId,
        amount: this.count(),
        imgUrl: imageUrl,
        name,
        price,
        description
      })
    }
  }
}
