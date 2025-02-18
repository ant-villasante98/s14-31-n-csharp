import { Component, Inject, OnInit, inject, signal } from '@angular/core';
import { CardShopComponent } from './components/card-shop/card-shop.component';
import { ResposeSearchFood } from '../../models/search-result';
import { SearchFoodService } from './services/search-food.service';
import { UpperCasePipe } from '@angular/common';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { of, switchMap } from 'rxjs';
import { Product } from '../../models/malls';
import { FoodModalComponent } from '../../shared/components/modals/food-modal/food-modal.component';
import { WraperFoodResultsComponent } from './components/wraper-food-results/wraper-food-results.component';

@Component({
  selector: 'app-search',
  standalone: true,
  imports: [CardShopComponent, UpperCasePipe, FoodModalComponent, WraperFoodResultsComponent],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css'
})
export class SearchComponent implements OnInit {
  foodSelected: Product | null = null
  imgShopSelected: string | null = null;
  nameShopSelected: string | null = null;
  localShopSelected: string | null = null;

  showFoodModal = signal<boolean>(false);
  finishSearch = signal<boolean>(false)

  private route = inject(ActivatedRoute)

  qSearch = signal<string>("")

  private _searchFoodService = inject(SearchFoodService)
  listResult = signal<ResposeSearchFood[]>([]);

  ngOnInit(): void {
    console.log(window.history.state.url)

    this.observerUrl()
  }

  observerUrl() {
    // console.log('observando')
    this.route.queryParamMap
      .pipe(
        switchMap((params: ParamMap) => {
          let q = params.get('q') ?? "";
          this.qSearch.set(q);
          return of(params);
        })
      ).subscribe({
        next: () => {
          this.search(this.qSearch());
        }
      })
  }

  search(q: string) {
    this.finishSearch.set(false);
    this._searchFoodService.search(q).subscribe({
      next: (res) => {
        console.log(res)
        this.listResult.set(res)
      },
      error: () => {
        this.finishSearch.set(true);
      },
      complete: () => {
        this.finishSearch.set(true);
      }
    }
    );
  }

  openInFoodModal(value: { food: Product, imgShop: string, nameShop: string, localShop: string }) {
    this.foodSelected = value.food;
    this.imgShopSelected = value.imgShop;
    this.nameShopSelected = value.nameShop;
    this.localShopSelected = value.localShop;
    this.showFoodModal.set(true);

  }

}
