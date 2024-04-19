import { Component, signal, OnInit, inject } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { NavbarFooterComponent } from '../navbar-footer/navbar.component';
import { SearchModalComponent } from '../../modals/search-modal/search-modal.component';
import { ShoppingCartManagerService } from '../../../services/shopping-cart-manager.service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink, RouterLinkActive, NavbarFooterComponent, SearchModalComponent],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit {

  showSearchModal = signal<boolean>(false)

  private _cartManager = inject(ShoppingCartManagerService);

  itemsCount = this._cartManager.cartContent;

  constructor() {
  }
  ngOnInit(): void {
  }

}
