import { HttpHandler, HttpHeaders, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { UserAuth } from '../../models/user-auth';
import { EnvService } from '../services/env.service';
import { AuthManagerService } from '../services/auth-manager.service';

export const apiInterceptor: HttpInterceptorFn = (req, next) => {
  console.log(`--Interceptor-API: peticion ${req.url}`)
  let API_URL: string = inject(EnvService).API_URL;
  let authManager = inject(AuthManagerService);

  // verificar si es la ruta de logink
  if (req.url === `${API_URL}/auth/login`) {

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

  // agregar los token  -- mejorar logica
  let newReq = authManager.addAccessToken(req);

  // let newReq = req.clone({ headers: req.headers.set("Authorization", `${userAuth.tokenType} ${userAuth.accessToken}`) })

  return next(newReq);
};
