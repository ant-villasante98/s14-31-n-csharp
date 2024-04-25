import { Component, Input, WritableSignal, signal } from '@angular/core';
import { MainModalComponent } from '../main-modal/main-modal.component';

@Component({
  selector: 'app-loading-modal',
  standalone: true,
  imports: [MainModalComponent],
  templateUrl: './loading-modal.component.html',
  styleUrl: './loading-modal.component.css'
})
export class LoadingModalComponent {
  message = signal<string>('')

  @Input({ alias: 'showModal', required: true }) showModal!: WritableSignal<boolean>;
  @Input({ alias: 'message' }) set setMessage(value: string) {
    this.message.set(value ?? "")
  }

}
