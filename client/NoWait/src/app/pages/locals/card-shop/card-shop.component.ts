import { Component, Input } from '@angular/core';
import { ResposeSearchFood } from '../../../models/search-result';
import { UpperCasePipe } from '@angular/common';

@Component({
  selector: 'app-card-shop',
  standalone: true,
  imports: [UpperCasePipe],
  templateUrl: './card-shop.component.html',
  styleUrl: './card-shop.component.css'
})
export class CardShopComponent {

  @Input({ alias: 'item-resul', required: true }) item!: ResposeSearchFood;
}
