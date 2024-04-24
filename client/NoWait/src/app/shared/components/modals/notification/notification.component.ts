import { Component, OnInit, inject, signal } from '@angular/core';
import { MainModalComponent } from '../main-modal/main-modal.component';
import { OrderNotification, NotificationService } from '../../../services/notification.service';

@Component({
  selector: 'app-notification',
  standalone: true,
  imports: [MainModalComponent],
  templateUrl: './notification.component.html',
})
export class NotificationComponent implements OnInit {

  private _notificationServices = inject(NotificationService);
  showNotification = signal<boolean>(false)

  notification: OrderNotification | null = null;
  messageNotification: Message = {
    title: "",
    description: ""
  };

  messagesList: Message[] = [
    // 0
    {
      title: "Orden Creada",
      description: "Tu orden fue creada con exito"
    },
    // 1
    {
      title: "Orden Pagada",
      description: "Orden creada y pagada"
    },
    // 2
    {
      title: "Orden Aceptada",
      description: "Tu orden fue aceptada por el local y sera preparada"
    },
    // 3
    {
      title: "Orden Lista",
      description: "Tu orden esta lista para que la retires"
    },
    // 4
    {
      title: "Orden Entregada",
      description: "Tu orden ya fue entregada"
    },
    // 5
    {
      title: "Orden Cancelada",
      description: "Tu orden fue cancelada"
    },
    // 6
    {
      title: "",
      description: ""
    }
  ]

  constructor() {
  }

  ngOnInit(): void {
    this._notificationServices.updateState.subscribe({
      next: (res) => {
        console.log(res)
        this.showNotification.set(true)
        this.notification = res
        this.messageNotification = this.messagesList[res.status.code] ?? 6
      }
    })
  }
}

export interface Message {
  title: string,
  description: string
}