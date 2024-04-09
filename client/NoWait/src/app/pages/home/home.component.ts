import { Component } from '@angular/core';
import { BannerHomeComponent } from '../../shared/components/banners/banner-home/banner-home.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [BannerHomeComponent],
  templateUrl: './home.component.html',
})
export class HomeComponent {

}
