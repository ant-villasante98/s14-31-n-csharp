import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-auth',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.css'
})
export class AuthComponent implements OnInit, OnDestroy {
  private router = inject(Router)
  private route = inject(ActivatedRoute)

  ngOnInit(): void {
    console.log(this.router.getCurrentNavigation()?.extras.state)
    console.log(window.history.state.url)
  }
  ngOnDestroy(): void {
    window.history.state.url = '/'
  }
}
