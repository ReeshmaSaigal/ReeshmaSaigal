import { Component } from '@angular/core';
import { AuthService } from '../../service/AuthService.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email!: string; // Definite assignment assertion
  password: string;
  loginError: boolean;
  isLoggedIn: boolean;

  constructor(private authService: AuthService, private router: Router) {
    this.email='';
    this.password='';
    this.loginError = false;
    this.isLoggedIn = false;
  }

  login() {
    const credentials = {
      email: this.email,
      password: this.password
    };

    this.authService.login(credentials).subscribe(
      () => {
        this.isLoggedIn = true;
        // Redirect to home or another page upon successful login
        this.router.navigate(['/admin-home']);
      },
      (error) => {
        console.error('Login failed:', error);
        this.loginError = true;
        // Handle login failure, show error message, etc.
      }
    );
  }

}
