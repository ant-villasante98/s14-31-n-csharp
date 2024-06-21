import { Component, OnInit, WritableSignal, inject, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EMPTY, of, switchMap, throwError } from 'rxjs';
import { Shop } from '../../models/malls';
import { MallsService } from '../../shared/services/malls.service';
import { ShopBannerComponent } from './components/shop-banner/shop-banner.component';
import { RecommendationsComponent } from './components/recommendations/recommendations.component';
import { ShopMenuComponent } from './components/shop-menu/shop-menu.component';

@Component({
  selector: 'app-shop-detail',
  standalone: true,
  imports: [ShopBannerComponent, RecommendationsComponent, ShopMenuComponent,],
  templateUrl: './shop-detail.component.html',
  styleUrl: './shop-detail.component.css'
})
export class ShopDetailComponent implements OnInit {
  private route = inject(ActivatedRoute);
  private _mallService = inject(MallsService)

  shop: WritableSignal<Shop | null> = signal(null);

  shopId: number = 0;

  ngOnInit(): void {
    this.route.paramMap.pipe(
      switchMap(params => {
        this.shopId = Number(params.get('id'));
        if (!this.shopId && this.shopId != 0) {
          return throwError(() => { });
        }
        return this._mallService.getShopById(this.shopId)
      })
    ).subscribe(
      {
        next: (res) => {
          this.shop.set(res);
        }
      }
    )
  }

}
