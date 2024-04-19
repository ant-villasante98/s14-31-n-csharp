import { Component, Inject, OnInit, inject, signal } from '@angular/core';
import { CardShopComponent } from './components/card-shop/card-shop.component';
import { ResposeSearchFood } from '../../models/search-result';
import { SearchFoodService } from './services/search-food.service';
import { UpperCasePipe } from '@angular/common';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { of, switchMap } from 'rxjs';

@Component({
  selector: 'app-search',
  standalone: true,
  imports: [CardShopComponent, UpperCasePipe],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css'
})
export class SearchComponent implements OnInit {

  finishSearch = signal<boolean>(false)

  private route = inject(ActivatedRoute)

  qSearch = signal<string>("")

  private _searchFoodService = inject(SearchFoodService)
  listResult = signal<ResposeSearchFood[]>([]);

  ngOnInit(): void {

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


}
