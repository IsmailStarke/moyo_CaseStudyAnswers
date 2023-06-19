import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private cartItems: any[] = [];

  constructor() { 
    this.loadCartItems();
  }

  private saveCartItems(): void {
    localStorage.setItem('cartItems', JSON.stringify(this.cartItems));
  }

  private loadCartItems(): void {
    const cartItems = localStorage.getItem('cartItems');
    if (cartItems) {
      this.cartItems = JSON.parse(cartItems);
    }
  }

  addToCart(item: any, quantity: number): void {
    const existingItem = this.cartItems.find((cartItem) => cartItem.productId === item.productId);
    if (existingItem) {
      existingItem.quantity += quantity; // Update the quantity
    } else {
      item.quantity = quantity; // Set the initial quantity
      this.cartItems.push(item);
    }
    this.saveCartItems();
  }

  getCartItems(): any[] {
    return this.cartItems;
  }

  clearCart(): void {
    this.cartItems = [];
    this.saveCartItems();
  }
}
