import { Component, Input, WritableSignal } from '@angular/core';

@Component({
  selector: 'app-msn-error',
  standalone: true,
  imports: [],
  templateUrl: './msn-error.component.html',
  styleUrl: './msn-error.component.css'
})
export class MsnErrorComponent {
  @Input({ required: true }) show!: WritableSignal<boolean>
}
