import { Component, OnInit, Signal, computed, inject, signal } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { NavbarFooterComponent } from '../../navbar-footer/navbar.component';
import { ShoppingCartManagerService } from '../../../services/shopping-cart-manager.service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink, RouterLinkActive, NavbarFooterComponent],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit {

  private _cartManager = inject(ShoppingCartManagerService);

  itemsCount = this._cartManager.cartContent;

  constructor() {
  }
  ngOnInit(): void {
  }

}
