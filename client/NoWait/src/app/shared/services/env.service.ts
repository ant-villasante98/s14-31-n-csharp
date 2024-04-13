import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EnvService {
  readonly HOST_API: string = "http://localhost:5065";
  readonly API_URL: string = `${this.HOST_API}/api`
  constructor() { }
}
