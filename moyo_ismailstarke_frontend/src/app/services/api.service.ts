import { Injectable } from '@angular/core';
import { Observable, map, of } from 'rxjs'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Product } from '../shared/product';
import { catchError } from 'rxjs/operators';
import { OrderResponseDTO } from '../shared/order-response-dto';


@Injectable({
  providedIn: 'root'
})
export class ApiService {
  apiUrl = 'https://localhost:7264/api/'
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private httpClient: HttpClient) { }

  //----------------------------------- Get All Products -----------------------------------------
  getAllProducts(): Observable<Product[]> {
    return this.httpClient.get<any>(`${this.apiUrl}Product/GetAllProducts`)
      .pipe(
        map(response => response.$values), // Extract the products from the response
        catchError((error: any) => {
          console.error(error);
          return of([]); // Return an empty array in case of an error
        })
      );
  }

  getProductById(productId: number): Observable<any> {
    const url = `${this.apiUrl}Product/GetProduct/${productId}`;
    return this.httpClient.get(url).pipe(
      catchError((error: any) => {
        throw error;
      })
    );
  }
  

  //--------------------------------- Get All Categories ------------------------------------------
  getCategories(): Observable<any> { 
    return this.httpClient.get(`${this.apiUrl}Category/GetAllCategories`)
  }

  //--------------------------------- Place Order ---------------------------------------------------
  placeOrder(orderBody: any): Observable<any> {
    const url = `${this.apiUrl}Store/PlaceOrder`;
    return this.httpClient.post<any>(url, orderBody, this.httpOptions)
      .pipe(
        catchError((error: any) => {
          console.error('Error placing order:', error);
          return of(null);
        })
      );
  }

  //----------------------------------- Get All Orders -----------------------------------------
  getAllOrders(): Observable<OrderResponseDTO[]> {
  return this.httpClient.get<OrderResponseDTO[]>(`${this.apiUrl}Store/GetAllOrders`, this.httpOptions)
    .pipe(
      catchError((error: any) => {
        console.error(error);
        return of([]); // Return an empty array in case of an error
      })
    );
  }

  //----------------------------------- Update Product -----------------------------------------
  updateProduct(product: Product): Observable<Product | null> {
    const url = `${this.apiUrl}Product/UpdateProduct/${product.productId}`;
    return this.httpClient.put<Product | null>(url, product, this.httpOptions).pipe(
      catchError((error: any) => {
        console.error('Error updating product:', error);
        return of(null);
      })
    );
  }
  
}
