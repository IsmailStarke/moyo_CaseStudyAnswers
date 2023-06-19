import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { CartService } from 'src/app/services/cart.service';
import { Product } from 'src/app/shared/product';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  cartItems: any[] = [];
  products: Product[] = [];
  orderPlaced: boolean = false;

  constructor(private http: HttpClient, private apiService: ApiService, private cartService: CartService, private auth: AuthenticationService, private router: Router) { }

  ngOnInit(): void {
    if (!this.auth.isLoggedIn()) {
      // If the user is not logged in, redirect them to the login page
      this.router.navigate(['/login']);
    } else {
      this.cartItems = this.cartService.getCartItems();
      this.populateProductNames();
    }
    
  }

  populateProductNames(): void {
    this.apiService.getAllProducts().subscribe(
      (products: Product[]) => {
        this.products = products;

        // Map the product names to the corresponding cart items
        for (const item of this.cartItems) {
          const matchingProduct = this.products.find(product => product.productId === item.productId);
          if (matchingProduct) {
            item.productName = matchingProduct.description;
          }
        }
      },
      (error: any) => {
        console.error('Error retrieving products:', error);
      }
    );
  }

  calculateOverallTotal(): number {
    let total = 0;
    for (const item of this.cartItems) {
      total += item.quantity * item.price;
    }
    return total;
  }

  isPlaceOrderButtonDisabled(): boolean {
    return this.cartItems.length === 0;
  }

  placeOrder(): void {
    if (this.isPlaceOrderButtonDisabled()) {
      return; // Don't proceed if the button is disabled
    }

    const email = localStorage.getItem('email') || '';
    const orderRequest = {
      orderDate: new Date().toISOString(),
      emailaddress: email,
      orderStatusId: 0,
      totalPrice: this.calculateOverallTotal(),
      productId: this.cartItems.map(item => item.productId),
      quantity: this.cartItems.map(item => item.quantity)
    };
  
    console.log(orderRequest);
    this.cartService.clearCart();
    this.cartItems = [];

    this.http.post('https://localhost:7264/api/Store/PlaceOrder', orderRequest)
    .subscribe(
      (response: any) => {
        if (response && response.text === 'Order placed successfully') {
          // Update orderRequest with the current date and time
          const updatedOrderRequest = {
            orderDate: new Date().toISOString(),
            emailaddress: orderRequest.emailaddress,
            orderStatusId: orderRequest.orderStatusId,
            totalPrice: orderRequest.totalPrice,
            productId: orderRequest.productId,
            quantity: orderRequest.quantity
          };
  
          console.log(updatedOrderRequest);
          this.orderPlaced = true;
        } else {
          console.error('Unexpected response:', response);
        }
      },
      (error: any) => {
        console.error('Error placing order:', error);
      }
    );
  }  

  clearCart(): void {
    this.cartService.clearCart();
    this.cartItems = [];
  }
}
