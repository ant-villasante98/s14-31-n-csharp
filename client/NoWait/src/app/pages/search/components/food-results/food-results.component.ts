import { UpperCasePipe } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ResposeSearchFood } from '../../../../models/search-result';
import { Product } from '../../../../models/malls';

@Component({
  selector: 'app-food-results',
  standalone: true,
  imports: [UpperCasePipe],
  templateUrl: './food-results.component.html',
  styleUrl: './food-results.component.css'
})
export class FoodResultsComponent {

  @Input({ required: true }) shop!: ResposeSearchFood;

  @Output() emitSelectedFood: EventEmitter<{ food: Product, imgShop: string, nameShop: string, localShop: string }> = new EventEmitter()

  errorHandlerFood(event: Event) {
    let img = event.target
    if (img instanceof HTMLImageElement) {
      img.src = 'assets/error-img.jpg'
    }
  }

  openInFoodModal(food: Product, imgShop: string, nameShop: string, localShop: string) {
    this.emitSelectedFood.emit({ food, imgShop, nameShop, localShop });

  }
}
