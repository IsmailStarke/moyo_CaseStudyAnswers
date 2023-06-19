import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  authenticationUrl = 'https://localhost:7264/api/Authentication'

  httpOptions = {
    headers: new HttpHeaders({
      ContentType: 'application.json'
    })
  }

  constructor(private http: HttpClient) { }

  //Register Functionality
  register(email: string, password: string): Observable<any> {
    const userData = {
      emailaddress: email,
      password: password
    };
    console.log(userData)
    return this.http.post(`${this.authenticationUrl}/Register`, userData, this.httpOptions);
  }

  //Login Functionality
  login(email: string, password: string):Observable<any> {
    const userData = {
      emailaddress: email,
      password: password
    };

    console.log(userData)
    return this.http.post(`${this.authenticationUrl}/Login`, userData)
  }

  //Store the token created once you have logged in
  storeToken(token: string, email: string): void {
    localStorage.setItem('token', token);
    localStorage.setItem('email', email);
  }

  //Retrieve the token from local storage
  getToken(): string | null {
    return localStorage.getItem('token')
  }

  //Logout Functionality
  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('email');
    localStorage.removeItem('cartItems');
  }

  //Ensures that you are logged in when you want to view the product page
  isLoggedIn(): boolean {
    return this.getToken() !== null;
  }

}
