import { HttpErrorResponse, HttpInterceptorFn, HttpStatusCode } from '@angular/common/http';
import { inject } from '@angular/core';
import { EMPTY, catchError, concatMap, finalize, throwError } from 'rxjs';
import { AuthService } from '../../pages/auth/services/auth.service';
import { Router } from '@angular/router';
import { EnvService } from '../services/env.service';
import { AuthManagerService } from '../services/auth-manager.service';

export const errorApiInterceptor: HttpInterceptorFn = (req, next) => {
  const API_URL = inject(EnvService).API_URL;
  const authService = inject(AuthService);
  const _authManager = inject(AuthManagerService);
  let router = inject(Router);

  console.log(`--Interceptor-Error: peticion ${req.url}`)


  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {

      // cuando el acceso es unauthorized
      if (error.status == HttpStatusCode.Unauthorized) {

        if (req.url === `${API_URL}/auth/refresh`) {
          router.navigateByUrl("/auth/login")
          return throwError(() => error);
        }

        let credentials = _authManager.getCredentials()
        if (!credentials) {
          router.navigateByUrl("/auth/login")
          return throwError(() => error);
        }
        console.log("Iniciando peticion de refresh token")
        if (_authManager.tokenRefreshing) {
          return EMPTY;
        }
        _authManager.tokenRefreshing = true
        return authService.refresh(credentials.refreshToken)
          .pipe(
            concatMap((response) => {
              //agregar las nuevas credenciales
              const newReq = _authManager.addAccessToken(req);
              //volver a llamar la anterior peticion
              return next(newReq);

            }),
            catchError(() => {
              //en caso no se pueda autorizar el refresh
              _authManager.rmCreadentials()
              router.navigateByUrl('/auth')
              return EMPTY
            }),
            finalize(() => {
              _authManager.tokenRefreshing = false;
            })
          )
      }
      return throwError(() => error);
    })
  );
};
