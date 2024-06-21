import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavbarFooterComponent } from './navbar.component';

describe('NavbarFooterComponent', () => {
  let component: NavbarFooterComponent;
  let fixture: ComponentFixture<NavbarFooterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NavbarFooterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NavbarFooterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
