import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map, of, pipe } from 'rxjs';
import { UserLogin } from '../../../../models/user-login';
import { UserAuth } from '../../../../models/user-auth';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly API_URL: string = "http://localhost:9009/api/auth"

  constructor(private httpClient: HttpClient) { }

  login(userlogin: UserLogin): Observable<UserAuth> {
    return this.httpClient.post<UserAuth>(`${this.API_URL}/login`, userlogin).pipe(
      map(res => {
        // guaradar las credenciales en le localStorage
        localStorage.setItem("value", JSON.stringify(res))
        return res
      })
    )
  }

  refresh(accessToken: string, refreshToken: string): Observable<UserAuth> {
    return of();
  }
}
