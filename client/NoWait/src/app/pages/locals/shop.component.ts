import { Component, OnInit, inject, signal } from '@angular/core';
import { MallsService } from '../../shared/services/malls.service';
import { CardShopComponent } from './card-shop/card-shop.component';
import { ResposeSearchFood } from '../../models/search-result';

@Component({
  selector: 'app-shop',
  standalone: true,
  imports: [CardShopComponent],
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.css'
})
export class ShopComponent implements OnInit {

  private _mallsService = inject(MallsService);
  listShops!: ResposeSearchFood[];

  finishSearch = signal<boolean>(false)

  ngOnInit(): void {
    this.getShops();
  }

  getShops() {
    this._mallsService.getShopsByMallId(1).subscribe({
      next: result => {
        this.listShops = result;
        console.log("Shops: ", this.listShops)
      },
      error: () => {
        this.finishSearch.set(true);
      },
      complete: () => {
        this.finishSearch.set(true);
      }
    });
  }
}
