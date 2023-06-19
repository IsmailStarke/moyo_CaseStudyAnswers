import { Component } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: '.app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {
  constructor(private auth: AuthenticationService, private router: Router) {}

  isActive(route: string): boolean {
    return this.router.url === route;
  }
  logout(): void {
    this.auth.logout();
    this.router.navigate(['/login']);
  }
}
