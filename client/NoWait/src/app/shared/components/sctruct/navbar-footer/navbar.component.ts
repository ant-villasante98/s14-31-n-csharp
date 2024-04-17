import { Component, Input, WritableSignal } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-navbar-footer',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarFooterComponent {
  @Input({ alias: "showSearchModal", required: true }) showSearchModal!: WritableSignal<boolean>;

}
