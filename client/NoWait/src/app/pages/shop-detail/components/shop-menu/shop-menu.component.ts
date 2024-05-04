import { Component, Input, WritableSignal, signal } from '@angular/core';
import { Product } from '../../../../models/malls';
import { FoodModalComponent } from '../../../../shared/components/modals/food-modal/food-modal.component';

@Component({
  selector: 'app-shop-menu',
  standalone: true,
  imports: [FoodModalComponent],
  templateUrl: './shop-menu.component.html',
  styleUrl: './shop-menu.component.css'
})
export class ShopMenuComponent {
  @Input({ required: true }) set setFoodList(value: Product[] | undefined) {
    this.foodList.set(value ?? []);
  }
  @Input() set setShopImg(value: string | undefined) {
    this.imgShopSelected = value ?? '';
  }

  @Input() set setShopName(value: string | undefined) {
    this.nameShopSelected = value ?? '';
  }

  @Input() set setShopAddress(value: string | undefined) {
    this.localShopSelected = value ?? '';
  }

  foodList: WritableSignal<Product[]> = signal([]);

  showFoodModal = signal<boolean>(false)

  foodSelected: Product | null = null;
  imgShopSelected: string | null = null;
  nameShopSelected: string | null = null;
  localShopSelected: string | null = null;

  openInFoodModal(food: Product) {
    this.foodSelected = food;
    this.showFoodModal.set(true);
  }

}
