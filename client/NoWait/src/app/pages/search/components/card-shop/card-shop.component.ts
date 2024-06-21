import { Component, Input } from '@angular/core';
import { ResposeSearchFood } from '../../../../models/search-result';
import { UpperCasePipe } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-card-shop',
  standalone: true,
  imports: [UpperCasePipe, RouterLink],
  templateUrl: './card-shop.component.html',
  styleUrl: './card-shop.component.css'
})
export class CardShopComponent {

  @Input({ alias: 'item-resul', required: true }) item!: ResposeSearchFood;

  errorHandler(event: Event) {
    let img = event.target
    if (img instanceof HTMLImageElement) {
      img.src = 'assets/Logo-Circulo.png'
    }

  }
}
