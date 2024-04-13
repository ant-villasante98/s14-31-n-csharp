import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { NavbarFooterComponent } from '../../navbar/navbar.component';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink, RouterLinkActive, NavbarFooterComponent],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {

}
