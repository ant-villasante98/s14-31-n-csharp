import { Component, Input, WritableSignal, computed } from '@angular/core';

@Component({
  selector: 'app-main-modal',
  standalone: true,
  imports: [],
  templateUrl: './main-modal.component.html',
  styleUrl: './main-modal.component.css'
})
export class MainModalComponent {
  @Input({ alias: "showModal", required: true }) showModal!: WritableSignal<boolean>;
  @Input({ alias: "staticModal" }) staticModal: boolean = false;

  modalEvent(e: any) {
    if (this.staticModal) {
      return;
    }

    if (!(e instanceof PointerEvent)) {
      return;
    }

    if (e.currentTarget == e.target) {
      this.showModal.set(false);
    }
  }

  activateSroll = computed(() => {
    console.log("Cambios en el modal");
    this.showModal()
    if (this.showModal()) {
      document.body.style.overflow = 'hidden'
      return
    }
    document.body.style.overflow = 'auto'
  })
}
