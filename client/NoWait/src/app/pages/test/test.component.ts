import { Component, OnInit, inject } from '@angular/core';
import { AuthService } from '../modals/login/services/auth.service';

@Component({
  selector: 'app-test',
  standalone: true,
  imports: [],
  templateUrl: './test.component.html',
  styleUrl: './test.component.css'
})
export class TestComponent implements OnInit {

  private _authService = inject(AuthService)
  ngOnInit(): void {
    this._authService.login({ email: "", password: "" })
      .subscribe({
        next: (data) => {
          console.log(data);
        }
      })
  }
}
