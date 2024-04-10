import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { EMPTY } from 'rxjs';

export const apiInterceptor: HttpInterceptorFn = (req, next) => {
  // verificar si es la ruta de login
  if (req.url === "") {
    return next(req);
  }

  // validar si se esta refrescando el token
  // if ("isRefresh" == "isRefresh" ) {
  //   return EMPTY;
  // }

  // validar si estan los datos del usuario y el refreshToken
  // if (true) {
  // inject(Router).navigateByUrl("/", { skipLocationChange: false });
  // }

  // agregar los token

  return next(req);
};
