import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: '.app-client-navbar',
  templateUrl: './client-navbar.component.html',
  styleUrls: ['./client-navbar.component.css']
})
export class ClientNavbarComponent implements OnInit {

  constructor(private authService: AuthenticationService, private router: Router) {}

  getCartItemCount(): number {
    const cartItems = JSON.parse(localStorage.getItem('cartItems') || '[]');
    let totalCount = 0;

    for (const item of cartItems) {
      totalCount += item.quantity;
    }

    return totalCount;
  }

  ngOnInit(): void {
  }

  isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
  
}
