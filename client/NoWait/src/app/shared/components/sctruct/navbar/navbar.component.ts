import { Component, signal } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { NavbarFooterComponent } from '../navbar-footer/navbar.component';
import { SearchModalComponent } from '../../modals/search-modal/search-modal.component';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink, RouterLinkActive, NavbarFooterComponent, SearchModalComponent],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {

  showSearchModal = signal<boolean>(false)

}
