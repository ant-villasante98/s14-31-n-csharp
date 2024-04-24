import { Injectable, inject } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { AuthService } from '../../pages/auth/services/auth.service';
import { AuthManagerService } from './auth-manager.service';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  private _authManager = inject(AuthManagerService);

  private connection!: HubConnection;

  private updateStateSubject = new Subject<OrderNotification>();
  private testSubject = new Subject<string>();

  get updateState() {
    return this.updateStateSubject.asObservable();
  }

  get test() {
    return this.testSubject.asObservable();
  }

  constructor() {
    this.setConfiguration()
  }

  setConfiguration() {
    if (this.connection instanceof HubConnection) {
      this.connection.stop();
    }
    let credentials = this._authManager.getCredentials()

    console.log('conectando con signalr');
    this.connection = new HubConnectionBuilder()
      .withUrl('https://s14.runasp.net/order-pos-hub', {
        accessTokenFactory: () => credentials?.accessToken ?? ''
      })
      .build();


    this.connection.start().then(() => {
      console.log('Conexión establecida con éxito');
    }).catch(err => {
      console.error('Error al conectar:', err);
    });

    this.connection.on("Test", (message) => {
      this.testSubject.next(message);
      console.log(message)
    })

    this.connection.on("OrderStatusUpdate", (email, orderId, status) => {
      console.log(email)
      console.log(orderId)
      console.log(status)
      this.updateStateSubject.next({ email, orderId, status } as OrderNotification)
    })

  }

  stopConnection() {
    this.connection.stop();
    this.setConfiguration();
  }
}

export interface OrderNotification {
  email: string;
  orderId: number;
  status: OrderStateNotification
}

export interface OrderStateNotification {
  code: number,
  caption: string
}
