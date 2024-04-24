import { AfterViewInit, Component, ElementRef, OnInit, ViewChild, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
// import { initFlowbite } from 'flowbite';
import { NavbarComponent } from './shared/components/sctruct/navbar/navbar.component';
import { BannerHomeComponent } from './pages/home/components/banner-home/banner-home.component';
import { LoginComponent } from './pages/auth/pages/login/login.component';
import { FooterComponent } from './shared/components/sctruct/footer/footer.component';
import { NotificationService } from './shared/services/notification.service';
import { NotificationComponent } from './shared/components/modals/notification/notification.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, NavbarComponent, BannerHomeComponent, LoginComponent, FooterComponent, NotificationComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit, AfterViewInit {
  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
  }
}
