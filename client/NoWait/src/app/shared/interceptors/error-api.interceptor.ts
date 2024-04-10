import { HttpErrorResponse, HttpInterceptorFn, HttpStatusCode } from '@angular/common/http';
import { inject } from '@angular/core';
import { EMPTY, catchError, concatMap, throwError } from 'rxjs';
import { AuthService } from '../../pages/modals/login/services/auth.service';
import { Router } from '@angular/router';

export const errorApiInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(AuthService)

  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      if (error.status == HttpStatusCode.Unauthorized) {
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
              // en caso no se pueda autorizar el refresh
              inject(Router).navigateByUrl("/")
              return EMPTY
            }),

          )
      }
      return throwError(() => error);
    })
  );
};
