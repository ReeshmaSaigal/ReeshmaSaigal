import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-set-password',
  templateUrl: './set-password.component.html',
  styleUrls: ['./set-password.component.css']
})
export class SetPasswordComponent implements OnInit {

  user = {
    password: '',
    confirmPassword: ''
  };

  signupId: string = '';
  passwordMismatch: boolean = false;
  emailVerified: boolean = false;
  isLoading: boolean = true;
  errorMessage: string = '';

  constructor(
    private authService: AuthService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getSignupIdAndVerifyEmail();
  }

  // ✅ Get signupId + verify email
  private getSignupIdAndVerifyEmail(): void {
    this.route.queryParams.subscribe(params => {
      this.signupId = params['signupid'];

      if (!this.signupId) {
        this.errorMessage = 'Invalid signup link';
        this.isLoading = false;
        return;
      }

      console.log('Signup ID:', this.signupId);

      this.verifyEmail();
    });
  }

  // ✅ Email verification API
  private verifyEmail(): void {
    this.authService.verifyEmail(this.signupId).subscribe({
      next: () => {
        this.emailVerified = true;
        this.isLoading = false;
      },
      error: (err) => {
        console.error(err);
        this.errorMessage = 'Email verification failed';
        this.emailVerified = false;
        this.isLoading = false;
      }
    });
  }

  // ✅ Real-time password match check
  checkPasswordMatch(): void {
    this.passwordMismatch =
      this.user.password !== this.user.confirmPassword;
  }

  // ✅ Submit form
  submitForm(form: any): void {

    if (form.invalid) return;

    if (this.user.password !== this.user.confirmPassword) {
      this.passwordMismatch = true;
      return;
    }

    this.passwordMismatch = false;
    this.isLoading = true;
    this.errorMessage = '';

    console.log('Submitting password...');

    this.authService.setNewPassword(this.user.password, this.signupId).subscribe({
      next: (res) => {
        console.log('Password set successfully:', res);

        this.isLoading = false;

        // ✅ Navigate to login
        this.router.navigate(['/login']);
      },
      error: (err) => {
        console.error(err);

        this.isLoading = false;

        // ✅ Show backend message if available
        this.errorMessage = err?.error || 'Failed to set password';
      }
    });
  }
}