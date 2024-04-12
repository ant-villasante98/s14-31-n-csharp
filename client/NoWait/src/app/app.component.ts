import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { initFlowbite } from 'flowbite';
import { NavbarComponent } from './shared/components/sctruct/navbar/navbar.component';
import { BannerHomeComponent } from './shared/components/banners/banner-home/banner-home.component';
import { LoginComponent } from './pages/modals/login/login.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, NavbarComponent, BannerHomeComponent, LoginComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'NoWait';
  ngOnInit(): void {
    initFlowbite();
  }
}
