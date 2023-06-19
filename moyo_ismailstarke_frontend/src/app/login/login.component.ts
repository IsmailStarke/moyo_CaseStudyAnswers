import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  passwordVisible: boolean = false;

  constructor(private auth: AuthenticationService, private router: Router) {}

  ngOnInit(): void {
    this.auth.logout();
  }

  login(): void {
    this.auth.login(this.email, this.password).subscribe(
      (response) => {
        this.auth.storeToken(response.token, this.email);
        if (this.email.endsWith('@serenespaces.co.za')) {
          this.router.navigate(['/dashboard']);
        } else {
          this.router.navigate(['/homepage']);
        }
      },
      (error) => {
        console.log('Login failed', error)
      }
    );
  }

  togglePasswordVisibility(): void {
    this.passwordVisible = !this.passwordVisible;
    const passwordInput = document.getElementById('passwordInput') as HTMLInputElement;
    passwordInput.type = this.passwordVisible ? 'text' : 'password';
  }
}
