import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router';
import { Product } from 'src/app/shared/product';
import { ApiService } from 'src/app/services/api.service';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-stock-take',
  templateUrl: './stock-take.component.html',
  styleUrls: ['./stock-take.component.css']
})
export class StockTakeComponent implements OnInit {
  products: Product[] = [];

  constructor(private http: HttpClient, private router: Router, private apiService: ApiService, private auth: AuthenticationService) {}

  ngOnInit(): void {
    if (!this.auth.isLoggedIn()) {
      // If the user is not logged in, redirect them to the login page
      this.router.navigate(['/login']);
    } else {
      this.getAllProducts();
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

  updateProduct(product: Product): void {
    const updatedProduct: Product = {
      ...product,
      price: product.price,
      productQuantity: product.productQuantity
    };
  
    this.apiService.updateProduct(updatedProduct).subscribe(
      (response: Product | null) => {
        if (response !== null) {
          const index = this.products.findIndex(
            (p) => p.productId === response.productId
          );
          if (index !== -1) {
            this.products[index].price = response.price;
            this.products[index].productQuantity = response.productQuantity;
          }
        }
      },
      (error: any) => {
        console.error('Error updating product:', error);
      }
    );
  }
}
