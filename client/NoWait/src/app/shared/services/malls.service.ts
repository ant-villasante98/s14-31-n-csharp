import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { EnvService } from './env.service';
import { Observable } from 'rxjs';
import { Mall, Shop } from '../../models/malls';

@Injectable({
  providedIn: 'root'
})
export class MallsService {

  private http = inject(HttpClient);
  private readonly API_URL: string = inject(EnvService).API_URL

  constructor() { }

  search(termSearch: string): Observable<any> {
    return this.http.get<any>(`${this.API_URL}/Malls/search?term=${termSearch}`);
  }

  getMalls(): Observable<Mall[]> {
    return this.http.get<Mall[]>(`${this.API_URL}/Malls`);
  }

  getMallById(mallId: number): Observable<Mall> {
    return this.http.get<Mall>(`${this.API_URL}/Malls/${mallId}`);
  }

  getShopsByMallId(mallId: number): Observable<any> {
    return this.http.get<any>(`${this.API_URL}/Malls/${mallId}/shops`);
  }

  getShopById(shopId: number): Observable<Shop> {
    return this.http.get<any>(`${this.API_URL}/shops/${shopId}`);
  }

  getMenuByShopId(shopId: number): Observable<any> {
    return this.http.get<any>(`${this.API_URL}/shops/${shopId}/menu`);
  }

  getItemById(itemId: number): Observable<any> {
    return this.http.get<any>(`${this.API_URL}/shops/menu/${itemId}`);
  }

}
