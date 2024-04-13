import { Injectable, signal } from '@angular/core';
import { UserAuth } from '../../models/user-auth';
import { HttpRequest } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthManagerService {
  private readonly nameStorage = "userCredentials"

  // controlar inicio y cierre de sesion
  // readonly sessionState = signal<boolean>(false)

  // controlar estado de peticion de refresh token
  tokenRefreshin: boolean = false;

  //obtencion de credenciales
  userCredentials: string | null = "";

  
  constructor() {     
  }
  
  getCredentials():UserAuth | null {
    let userAuthString = localStorage.getItem(this.nameStorage);
    if (!userAuthString) {
      return null;
    }
  
    let userAuth: UserAuth = JSON.parse(userAuthString);
    if (this.isNotValidateUserAuth(userAuth))
    {
      return null;
    }

    return userAuth;
  }

  // setear crendenciales en el local starage
  setCredentials(credenciales: UserAuth) {
    localStorage.setItem(this.nameStorage, JSON.stringify(credenciales))
  }
  
  // obtener el refresh token

  // agreagar credencilas al header
  addAccessToken(req: HttpRequest<unknown>):HttpRequest<unknown> {
    let headers = req.headers;
    let userAuth: UserAuth | null = this.getCredentials();
    if (userAuth) {
      headers = headers.set("Authorization", `${userAuth.tokenType} ${userAuth.accessToken}`);
    }

    return req.clone({ headers });
  }

  // validar UserAuth
  isNotValidateUserAuth(value: UserAuth): boolean {
    let res: boolean = value.accessToken == undefined || value.refreshToken == undefined || value.tokenType == undefined;
    return res;
  }
}
