import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { EnvService } from './env.service';
import { Observable } from 'rxjs';
import { CreateOrder, Order } from '../../models/orders';
import { Payment } from '../../models/payment';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private http = inject(HttpClient);
  private readonly API_URL: string = inject(EnvService).API_URL + "/Orders"

  constructor() { }

  createOrder(order: CreateOrder): Observable<any>{
    return this.http.post<any>(this.API_URL, order);
  }

  getOrder(orderId: number): Observable<Order>{
    return this.http.get<Order>(`${this.API_URL}/${orderId}`);
  }

  payOrder(orderId: number): Observable<Payment>{
    return this.http.put<Payment>(`${this.API_URL}/${orderId}/pay`, {});
  }
  
  prepareOrder(orderId: number): Observable<any>{
    return this.http.put<any>(`${this.API_URL}/${orderId}/prepare`, {});
  }

  orderReady(orderId: number): Observable<any>{
    return this.http.put<any>(`${this.API_URL}/${orderId}/ready-to-deliver`, {});
  }

  finishedOrder(orderId: number): Observable<any>{
    return this.http.put<any>(`${this.API_URL}/${orderId}/finish`, {});
  }

  cancelOrder(orderId: number): Observable<any>{
    return this.http.put<any>(`${this.API_URL}/${orderId}/cancel`, {});
  }
}
