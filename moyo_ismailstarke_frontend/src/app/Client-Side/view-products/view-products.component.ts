import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router';
import { Product } from 'src/app/shared/product';
import { ApiService } from 'src/app/services/api.service';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-view-products',
  templateUrl: './view-products.component.html',
  styleUrls: ['./view-products.component.css']
})
export class ViewProductsComponent implements OnInit {
  products: Product[] = [];

  constructor(private http: HttpClient, private router: Router, private apiService: ApiService, private auth: AuthenticationService, private cartService: CartService) {}

  ngOnInit(): void {
    if (!this.auth.isLoggedIn()) {
      // If the user is not logged in, redirect them to the login page
      this.router.navigate(['/login']);
    } else {
      this.getAllProducts();
      // Initialize products array
      this.products = [
        // Add your product objects here
      ];
    }
  } 

  getAllProducts(): void {
    this.apiService.getAllProducts().subscribe(
      (products: Product[]) => {
        this.products = products;
      },
      (error: any) => {
        console.error(error)
      }
    )
  }

  //----------------------------------------- Add To Cart -------------------------------------------
  addToCart(product: any): void {
    const quantityInput = document.getElementById('quantity' + product.productId) as HTMLInputElement;
    const quantity = parseInt(quantityInput.value, 10);
    if (quantity > 0 && quantity <= 5) {
      this.cartService.addToCart(product, quantity);
      quantityInput.value = '1'; // Reset the quantity input to 1
    } else {
      
    }
  } 

}
