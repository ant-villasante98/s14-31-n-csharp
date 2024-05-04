import { Component, Input, WritableSignal, signal } from '@angular/core';

@Component({
  selector: 'app-shop-banner',
  standalone: true,
  imports: [],
  templateUrl: './shop-banner.component.html',
  styleUrl: './shop-banner.component.css'
})
export class ShopBannerComponent {
  @Input({ required: true }) set setshopName(value: string | undefined) {
    this.shopName.set(value ?? "")
  }
  @Input({ required: true }) set setshopLogoImg(value: string | undefined) {
    this.shopLogoImg.set(value ?? "")
  };
  @Input({ required: true }) set setshopBannerImg(value: string | undefined) {
    this.shopBannerImg.set(value ?? "")
  }
  @Input({ required: true }) set setshopAddress(value: string | undefined) {
    this.shopAddress.set(value ?? "")
  }

  shopName: WritableSignal<string> = signal('');
  shopLogoImg: WritableSignal<string> = signal('');
  shopBannerImg: WritableSignal<string> = signal('');
  shopAddress: WritableSignal<string> = signal('');
}
