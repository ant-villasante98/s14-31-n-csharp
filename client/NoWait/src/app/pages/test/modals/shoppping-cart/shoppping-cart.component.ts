import { Component, Input, WritableSignal } from '@angular/core';
import { MainModalComponent } from '../main-modal/main-modal.component';

@Component({
  selector: 'app-shoppping-cart',
  standalone: true,
  imports: [MainModalComponent],
  templateUrl: './shoppping-cart.component.html',
  styleUrl: './shoppping-cart.component.css'
})
export class ShopppingCartComponent {
  @Input({ alias: "showModal", required: true }) showModal!: WritableSignal<boolean>;




}
