import { TestBed } from '@angular/core/testing';

import { ShoppingCartManagerService } from './shopping-cart-manager.service';

describe('ShoppingCartManagerService', () => {
  let service: ShoppingCartManagerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ShoppingCartManagerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
