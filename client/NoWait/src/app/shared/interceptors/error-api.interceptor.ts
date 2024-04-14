import { HttpErrorResponse, HttpInterceptorFn, HttpStatusCode } from '@angular/common/http';
import { inject } from '@angular/core';
import { EMPTY, catchError, concatMap, throwError } from 'rxjs';
import { AuthService } from '../../pages/auth/services/auth.service';
import { Router } from '@angular/router';
import { EnvService } from '../services/env.service';

export const errorApiInterceptor: HttpInterceptorFn = (req, next) => {
  console.log(`--Interceptor-Error: peticion ${req.url}`)

  const API_URL = inject(EnvService).API_URL;
  const authService = inject(AuthService);
  let router = inject(Router);

  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {

      // cuando el acces
      if (error.status == HttpStatusCode.Unauthorized) {
        if (req.url === `${API_URL}/auth/refresh`) {
          console.log("ERROR-1: Refresh token invalido.")
          // router.navigateByUrl("/auth/login")
          return EMPTY;
        }
        authService.refresh("", "")
          .pipe(
            concatMap((response) => {
              // actualizar las credenciales(userId, accessToken, refreshToken,etc)
              console.log("creadenciales actualizadas");

              // volver a llamar la anterior peticion
              // agregar las nuevas credenciales
              const newReq = req.clone();
              return next(newReq);

            }),
            catchError(() => {
              console.log("ERROR-2: Refresh token invalido.")
              // en caso no se pueda autorizar el refresh
              // router.navigateByUrl("/")
              return EMPTY
            }),

          )
      }
      return throwError(() => error);
    })
  );
};
