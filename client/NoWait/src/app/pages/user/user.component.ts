import { Component, inject, OnInit } from '@angular/core';
import { UserService } from '../../shared/services/user.service';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent implements OnInit {

  private _userService = inject(UserService);

  ngOnInit(): void {
    console.log("Entrando al area de usuario")
    this._userService.getClaims().subscribe({
      next: (v) => {
      }
    })
  }
}
