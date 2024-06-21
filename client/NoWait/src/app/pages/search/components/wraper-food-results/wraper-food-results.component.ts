import { Component, EventEmitter, Input, Output, signal } from '@angular/core';
import { FoodResultsComponent } from '../food-results/food-results.component';
import { ResposeSearchFood } from '../../../../models/search-result';
import { Product } from '../../../../models/malls';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-wraper-food-results',
  standalone: true,
  imports: [FoodResultsComponent, NgClass],
  templateUrl: './wraper-food-results.component.html',
  styleUrl: './wraper-food-results.component.css'
})
export class WraperFoodResultsComponent {
  @Input({ required: true }) shop!: ResposeSearchFood;
  @Output() emitSelectedFood: EventEmitter<{ food: Product, imgShop: string, nameShop: string, localShop: string }> = new EventEmitter()

  showFoodResult = signal<boolean>(false);

  openInFoodModal(value: { food: Product, imgShop: string, nameShop: string, localShop: string }) {
    this.emitSelectedFood.emit(value);

  }
}
