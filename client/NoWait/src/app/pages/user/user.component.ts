import { Component, inject, OnInit } from '@angular/core';
import { UserService } from '../../shared/services/user.service';
import { AuthManagerService } from '../../shared/services/auth-manager.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent implements OnInit {
  private _authManager = inject(AuthManagerService);
  private router = inject(Router);

  private _userService = inject(UserService);

  ngOnInit(): void {
    this._userService.getClaims().subscribe({
      next: (v) => {
      }
    })
  }

  logOut() {
    this._authManager.rmCreadentials();
    this.router.navigateByUrl('/auth')
  }
}
