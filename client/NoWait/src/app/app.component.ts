import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
// import { initFlowbite } from 'flowbite';
import { NavbarComponent } from './shared/components/sctruct/navbar/navbar.component';
import { BannerHomeComponent } from './pages/home/components/banner-home/banner-home.component';
import { LoginComponent } from './pages/auth/pages/login/login.component';
import { FooterComponent } from './shared/components/sctruct/footer/footer.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, NavbarComponent, BannerHomeComponent, LoginComponent, FooterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'NoWait';
  ngOnInit(): void {
    // initFlowbite();
  }
}
