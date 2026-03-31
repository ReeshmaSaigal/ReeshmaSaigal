import { Component } from '@angular/core';
import { AuthServiceService } from '../../service/auth-service.service';
import { Router } from '@angular/router';
import { Login } from '../../model/login';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor(private authService: AuthServiceService, private router: Router) { }
  
  loginSubmit(loginForm: NgForm) {
    if (loginForm.valid) {
      console.log('Form Values:', loginForm.value);
      this.authService.login(loginForm.value).subscribe(
        result => {
          console.log('Login successful:', result);
          // Navigate to dashboard only if login is successful
          this.router.navigate(['admin/dashboard']);
        },
        error => {
          console.error('Login failed:', error);
          // Handle login failure (e.g., show an error message to the user)
        }
      );
    } else {
      console.log('Form is invalid');
    }
  }
}
