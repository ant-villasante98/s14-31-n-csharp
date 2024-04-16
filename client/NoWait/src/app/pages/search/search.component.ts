import { Component } from '@angular/core';
import { CardShopComponent } from '../../shared/components/card-shop/card-shop.component';

@Component({
  selector: 'app-search',
  standalone: true,
  imports: [CardShopComponent],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css'
})
export class SearchComponent {

}
