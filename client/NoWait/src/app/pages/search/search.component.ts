import { Component } from '@angular/core';
import { CardShopComponent } from './components/card-shop/card-shop.component';
import { SearchShop } from '../../models/search-result';

@Component({
  selector: 'app-search',
  standalone: true,
  imports: [CardShopComponent],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css'
})
export class SearchComponent {


  listResult: SearchShop[] = result;

}

export const result: SearchShop[] = [
  {
    id: 1,
    name: "BURGER 1982 ",
    description: "Hacemos las mejores hamburguesas del mundo en tiempo récord.",
    url: "https://iili.io/J8xeO3F.png"
  },
  {
    id: 1,
    name: "KOKÍ RESTO",
    description: "Comida rica y abundante.",
    url: "https://iili.io/J8xOm11.png"
  },
  {
    id: 1,
    name: "ENTRE panes",
    description: "Delicioso y casero.",
    url: "https://iili.io/J8xOOb4.png"
  },
  {
    id: 1,
    name: "Pattiz",
    description: "Comida rica y abundante.",
    url: "https://i.pinimg.com/736x/ab/80/bd/ab80bdba53a516e12e12f26a336f6f7e.jpg"
  },
  {
    id: 1,
    name: "HAMBURGUESA pink",
    description: "Pan de remolacha.",
    url: "https://i.pinimg.com/736x/f8/32/a5/f832a59135baa1b4d46c5000565e1e36.jpg"
  },
  {
    id: 1,
    name: "The Good Life",
    description: "Disfruta la vida.",
    url: "https://i.pinimg.com/736x/83/2c/0d/832c0d93f563c9a1a2ebb14611b09bb6.jpg"
  },
]
