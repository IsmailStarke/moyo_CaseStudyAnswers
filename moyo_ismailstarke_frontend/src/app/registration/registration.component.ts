import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {
  email: string = '';
  password: string = '';
  passwordVisible: boolean = false;

  constructor(private auth: AuthenticationService, private router: Router) {}

  register(): void {
    this.auth.register(this.email, this.password).subscribe(
      (response) => {
        this.router.navigate(['/login']);
      },
      (error) => {
        console.log('Registration failed', error);
      }
    );
  }
  
  togglePasswordVisibility(): void {
    this.passwordVisible = !this.passwordVisible;
    const passwordInput = document.getElementById('passwordInput') as HTMLInputElement;
    passwordInput.type = this.passwordVisible ? 'text' : 'password';
  }
}
