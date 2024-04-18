import { TestBed } from '@angular/core/testing';

import { SearchFoodService } from './search-food.service';

describe('SearchFoodService', () => {
  let service: SearchFoodService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SearchFoodService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
