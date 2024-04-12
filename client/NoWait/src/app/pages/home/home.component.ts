import { Component } from '@angular/core';
import { BannerHomeComponent } from '../../shared/components/banners/banner-home/banner-home.component';
import { CardComponent } from '../../shared/components/card/card.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [BannerHomeComponent, CardComponent],
  templateUrl: './home.component.html',
})
export class HomeComponent {

}
