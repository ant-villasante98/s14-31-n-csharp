import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map, of } from 'rxjs';
import { UserLogin } from '../../../../models/user-login';
import { UserAuth } from '../../../../models/user-auth';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly API_URL: string = "https://randomuser.me/api/0.8/?results=1"

  constructor(private httpClient: HttpClient) { }

  login(userlogin: UserLogin): Observable<UserAuth> {
    return this.httpClient.get(this.API_URL).pipe(
      map((res: any) => {
        console.log(res)
        const [data] = res?.results;
        let authLogin: UserAuth = { userId: data?.user?.dob, accessToken: data?.user?.sha256, refreshToken: data?.user?.sha1 }
        return authLogin;
      })
    )
  }

  refresh(accessToken: string, refreshToken: string): Observable<UserAuth> {
    return of({ userId: 123, accessToken: "asdffsd", refreshToken: "adfask;lxck" });
  }
}
