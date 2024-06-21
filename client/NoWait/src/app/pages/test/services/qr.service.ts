import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QrService {
  private API_URL: string = "http://localhost:5065/api/qr";

  constructor(private _httpClient: HttpClient) {
    console.log("Hola des de qrservice")
  }

  getSVGElement(orderId: number): Observable<string> {
    const headers = new HttpHeaders();
    headers.set('Accept', 'image/svg+xml')
    return this._httpClient.get(`${this.API_URL}/get-svg/${orderId}`, { headers, responseType: 'arraybuffer' })
      .pipe(
        map((res: ArrayBuffer) => {
          var enc = new TextDecoder("utf-8")
          return enc.decode(res);
        })
      )
  }

  getSVGEncoden(orderId: number): Observable<any> {
    return this._httpClient.put(`${this.API_URL}/generate-qr/${orderId}`, {})
      .pipe(
        map((res: any) => {
          console.log("inicio peticion")
          console.log(res)
          return res
        })
      )
  }

  test(): Observable<any> {
    return this._httpClient.get('http://localhost:9009/weatherforecast').pipe(
      map((res) => {
        console.log(res);
      })
    )
  }
}
