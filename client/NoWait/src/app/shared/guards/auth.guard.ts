import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { AuthManagerService } from '../services/auth-manager.service';

export const authGuard: CanActivateFn = (route, state) => {
  let router = inject(Router);
  let authManager = inject(AuthManagerService);
  let creadenciales = authManager.getCredentials()
  if (creadenciales) {
    return true;
  }
  router.navigate(['/auth'])
  return false
};
