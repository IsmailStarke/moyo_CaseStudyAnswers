import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { OrderResponseDTO } from 'src/app/shared/order-response-dto';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  orders: OrderResponseDTO[] = [];
  
  constructor(private apiService: ApiService, private auth: AuthenticationService, private route: Router) {}

  ngOnInit(): void {
    if (!this.auth.isLoggedIn()) {
      // If the user is not logged in, redirect them to the login page
      this.route.navigate(['/login']);
    } else {
      this.fetchOrders(); // Fetch orders if the user is logged in
    }
  }

  fetchOrders(): void {
    this.apiService.getAllOrders().subscribe(
      (orders: OrderResponseDTO[]) => {
        this.orders = orders;
      },
      (error) => {
        console.error('Error fetching orders:', error);
      }
    );
  }
}
