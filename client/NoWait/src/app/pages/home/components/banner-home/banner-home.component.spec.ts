import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BannerHomeComponent } from './banner-home.component';

describe('BannerHomeComponent', () => {
  let component: BannerHomeComponent;
  let fixture: ComponentFixture<BannerHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BannerHomeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BannerHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
