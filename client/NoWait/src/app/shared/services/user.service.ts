import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EnvService } from './env.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private httpClient = inject(HttpClient);

  private readonly API_URL: string = inject(EnvService).API_URL + "/test/GetActualUserClaims";

  constructor() { }

  getClaims(): Observable<string[]> {
    return this.httpClient.get<string[]>(this.API_URL)
  }
}
