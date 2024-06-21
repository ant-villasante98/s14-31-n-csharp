import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, map, of } from 'rxjs';
import { EnvService } from '../../../shared/services/env.service';
import { UserAuth } from '../../../models/user-auth';
import { UserLogin } from '../../../models/user-login';
import { AuthManagerService } from '../../../shared/services/auth-manager.service';
import { NotificationService } from '../../../shared/services/notification.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private httpClient = inject(HttpClient);
  private _authManager = inject(AuthManagerService);
  private _notificationService = inject(NotificationService)

  private readonly API_URL: string = inject(EnvService).API_URL + "/auth";

  constructor() { }

  login(userlogin: UserLogin): Observable<UserAuth> {
    return this.httpClient.post<UserAuth>(`${this.API_URL}/login`, userlogin).pipe(
      map(res => {
        // guardar las credenciales en le localStorage
        this._authManager.setCredentials(res)
        this._notificationService.setConfiguration()
        return res
      })
    )
  }

  register(userlogin: UserLogin): Observable<any> {
    return this.httpClient.post<any>(`${this.API_URL}/register`, userlogin);
  }

  refresh(refreshToken: string): Observable<UserAuth> {
    // return of().pipe(map((res) => {
    //   this._notificationService.setConfiguration()
    //   return res
    // }));
    return this.httpClient.post<UserAuth>(`${this.API_URL}/refresh`, { refreshToken })
      .pipe(
        map(res => {
          this._authManager.setCredentials(res)
          this._notificationService.setConfiguration()
          return res
        })
      )
  }
}
