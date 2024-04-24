import { Component, OnInit, inject, signal } from '@angular/core';
import { MainModalComponent } from '../main-modal/main-modal.component';
import { Notification, NotificationService } from '../../../services/notification.service';

@Component({
  selector: 'app-notification',
  standalone: true,
  imports: [MainModalComponent],
  templateUrl: './notification.component.html',
})
export class NotificationComponent implements OnInit {

  private _notificationServices = inject(NotificationService);
  showNotification = signal<boolean>(false)

  notification: Notification | null = null;

  constructor() {
  }

  ngOnInit(): void {
    this._notificationServices.updateState.subscribe({
      next: (res) => {
        console.log(res)
        this.showNotification.set(true)
        this.notification = res
      }
    })
  }
}
