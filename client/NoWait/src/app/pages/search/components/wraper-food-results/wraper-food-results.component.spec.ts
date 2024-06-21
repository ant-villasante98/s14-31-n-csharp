import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WraperFoodResultsComponent } from './wraper-food-results.component';

describe('WraperFoodResultsComponent', () => {
  let component: WraperFoodResultsComponent;
  let fixture: ComponentFixture<WraperFoodResultsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WraperFoodResultsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WraperFoodResultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
