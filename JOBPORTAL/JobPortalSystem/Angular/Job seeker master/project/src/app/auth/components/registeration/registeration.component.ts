import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registeration',
  templateUrl: './registeration.component.html',
  styleUrls: ['./registeration.component.css']
})
export class RegisterationComponent {

  isLoading: boolean = false;   // ✅ better name than show
  error: string = '';           // ✅ fix your previous error

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  signUp(signUpForm: NgForm) {

    if (signUpForm.invalid) return;

    this.isLoading = true;  // ✅ start loader
    this.error = '';

    console.log(signUpForm.value);

    this.authService.signUp(signUpForm.value).subscribe({
      next: (response) => {
        console.log(response);

        this.isLoading = false;

        // ✅ redirect after success
        this.router.navigate(['/login']);
      },

      error: (err) => {
        console.error(err);

        this.isLoading = false;

        // ✅ show error in UI
        this.error = err.error || 'Registration failed';
      }
    });
  }
}