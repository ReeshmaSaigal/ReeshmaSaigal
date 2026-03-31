import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-set-password',
  templateUrl: './set-password.component.html',
  styleUrls: ['./set-password.component.css']
})
export class SetPasswordComponent implements OnInit {
  user = {
    password: '',
    confirmPassword: '',
  };
  signupId: any;
  passwordMismatch = false;
  emailVerified: boolean = false;
  isLoading: boolean = true;

  constructor(private authService: AuthService, private route: ActivatedRoute, private router: Router) {}

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.signupId = params['signupid'];
      // alert(this.signupId);
    

      this.authService.verifyEmail(this.signupId).subscribe(
        response => {
          // alert("sree");
          console.log('Response from verify-email:', response);
            // alert(response.statusCode)
            this.emailVerified=true;
          // if (response && response.status === 200) {
          //   this.emailVerified = true;
          // } else {
           
          //   console.error('Email verification failed:', response);
          // }

          this.isLoading = false; // Hide the spinner once email verification is complete
        },
        error => {
          alert("Error occurred during email verification:")
          console.error('Error occurred during email verification:', error);
          this.isLoading = false; // Ensure that the spinner is hidden on error
        }
      );
    });               
  }

  submitForm(form: any) {
    if (form.valid) {
      if (this.user.password !== this.user.confirmPassword) {
        this.passwordMismatch = true;
        return;
      }
  
      // Reset password mismatch if it was previously set
      this.passwordMismatch = false;
  
      console.log('Form submitted:', this.user);
      alert("hello");
  
      this.authService.setNewPassword(this.user.password, this.signupId).subscribe(
        (response: HttpResponse<string>) => {
          const statusCode = response.status;
          console.log(`Status Code: ${statusCode}`);
          alert(response.status);
  
          if (statusCode === 200) {
            this.router.navigate(['/login']);
          } else {
            console.error('Failed to set a new password. Status Code:', statusCode);
            // You can add additional error handling logic here if needed
          }
        },
        error => {
          console.error('HTTP error occurred while setting a new password:', error);
  
          if (error.status === 401) {
            // Handle unauthorized error (e.g., show a message to the user)
          } else if (error.status === 403) {
            // Handle forbidden error
          } else {
            // Handle other errors
            // For now, redirect to the login page for any other error
            this.router.navigate(['/login']);
          }
        }
      );
    }
  }
  
  
}
