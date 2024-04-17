import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { EnvService } from '../../../shared/services/env.service';
import { Observable } from 'rxjs';
import { ResposeSearchFood } from '../../../models/search-result';

@Injectable({
  providedIn: 'root'
})
export class SearchFoodService {

  private API_URL = inject(EnvService).API_URL;
  private _httpClient = inject(HttpClient);
  constructor() { }

  search(q: string): Observable<ResposeSearchFood[]> {
    let params = new HttpParams();
    params = params.append("term", q);
    return this._httpClient.get<ResposeSearchFood[]>(`${this.API_URL}/malls/search`, { params, responseType: "json" })
  }
}
