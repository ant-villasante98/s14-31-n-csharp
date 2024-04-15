import { Component, Input, WritableSignal } from '@angular/core';
import { MainModalComponent } from '../main-modal/main-modal.component';

@Component({
  selector: 'app-search-modal',
  standalone: true,
  imports: [MainModalComponent],
  templateUrl: './search-modal.component.html',
  styleUrl: './search-modal.component.css'
})
export class SearchModalComponent {

  @Input({ alias: "showModal", required: true }) showModal!: WritableSignal<boolean>;



  modalEvent(e: any) {
    console.log(e)
    if (e instanceof PointerEvent) {
      if (e.currentTarget == e.target) {
        this.showModal.set(false);
      }
    }
  }


}
