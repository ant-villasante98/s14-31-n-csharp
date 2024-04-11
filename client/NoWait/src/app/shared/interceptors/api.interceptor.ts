import { HttpHandler, HttpHeaders, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { UserAuth } from '../../models/user-auth';

export const apiInterceptor: HttpInterceptorFn = (req, next) => {
  // verificar si es la ruta de login
  if (req.url === "http://localhost:9009/api/auth/login") {

    return next(req);
  }

  // validar si se esta refrescando el token
  // if ("isRefresh" == "isRefresh" ) {
  //   return EMPTY;
  // }

  // validar si estan los datos del usuario y el refreshToken
  // if (true) {
  // inject(Router).navigateByUrl("/", { skipLocationChange: false });
  //   return EMPTY;
  // }

  // agregar los token -- llevar a una funcion
  let userAuth: UserAuth = JSON.parse(localStorage.getItem("value") ?? "");

  let headers = req.headers;
  headers = headers.set("Authorization", `${userAuth.tokenType} ${userAuth.accessToken}`);
  let newReq = req.clone({
    headers
  });

  // let newReq = req.clone({ headers: req.headers.set("Authorization", `${userAuth.tokenType} ${userAuth.accessToken}`) })

  return next(newReq);
};
