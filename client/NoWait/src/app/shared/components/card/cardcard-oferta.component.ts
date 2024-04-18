import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-card-oferta',
  standalone: true,
  imports: [],
  templateUrl: './card-oferta.component.html',
  styleUrl: './card-oferta.component.css'
})
export class CardOfertaComponent {
  @Input("imgSrc") imgSrc: string = ""
}
