import { Component } from '@angular/core';
import { BannerHomeComponent } from '../../shared/components/banners/banner-home/banner-home.component';
import { CardOfertaComponent } from '../../shared/components/card/cardcard-oferta.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [BannerHomeComponent, CardOfertaComponent],
  templateUrl: './home.component.html',
})
export class HomeComponent {

}
