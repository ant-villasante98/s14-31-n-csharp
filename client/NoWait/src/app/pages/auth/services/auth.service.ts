import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, map, of} from 'rxjs';
import { EnvService } from '../../../shared/services/env.service';
import { UserAuth } from '../../../models/user-auth';
import { UserLogin } from '../../../models/user-login';
import { AuthManagerService } from '../../../shared/services/auth-manager.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private httpClient = inject(HttpClient);
  private _authManager = inject(AuthManagerService);

  private readonly API_URL: string = inject(EnvService).API_URL + "/auth";

  constructor() { }

  login(userlogin: UserLogin): Observable<UserAuth> {
    return this.httpClient.post<UserAuth>(`${this.API_URL}/login`, userlogin).pipe(
      map(res => {
        // guardar las credenciales en le localStorage
        this._authManager.setCredentials(res)
        return res
      })
    )
  }
  
  register(userlogin: UserLogin): Observable<any> {
    return this.httpClient.post<any>(`${this.API_URL}/register`, userlogin);
  }

  refresh(accessToken: string, refreshToken: string): Observable<UserAuth> {
    return of();
  }
}
