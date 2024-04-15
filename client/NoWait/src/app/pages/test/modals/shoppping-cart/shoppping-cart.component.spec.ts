import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShopppingCartComponent } from './shoppping-cart.component';

describe('ShopppingCartComponent', () => {
  let component: ShopppingCartComponent;
  let fixture: ComponentFixture<ShopppingCartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ShopppingCartComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ShopppingCartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
