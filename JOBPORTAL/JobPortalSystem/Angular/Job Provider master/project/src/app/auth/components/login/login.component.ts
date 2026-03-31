import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { UserLogin } from '../../models/login';
import { CompanyService } from 'src/app/company/services/company.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  errorMessage: string = '';
  isSubmitted: boolean = false;

  constructor(
    private authService: AuthService,
    private router: Router,
    private companyService: CompanyService
  ) { }

  login(loginForm: NgForm) {

    this.isSubmitted = true;
    this.errorMessage = '';

    if (loginForm.invalid) {
      this.errorMessage = 'Please enter email and password';
      return;
    }

    const userlogin: UserLogin = {
      email: loginForm.value.email,
      password: loginForm.value.password
    };

    this.authService.login(userlogin).subscribe({

      next: (res) => {

        console.log("Login Success:", res);

        // ✅ Store basic auth data
        localStorage.setItem('token', res.token);
        localStorage.setItem('jobProviderId', res.id);
        localStorage.setItem('role', res.role);

        // 🔥 Get company details
        this.companyService.getCompany().subscribe({

          next: (companyRes) => {

            console.log("Company FULL RESPONSE:", companyRes);
            if (companyRes) 
            {
              const company = companyRes[0];

              // ✅ Store separately (VERY IMPORTANT)
              const companyId = company.companyId || company.company || company.id;
              const companyUserId = company.id;

              localStorage.setItem('companyId', companyId);
              localStorage.setItem('companyUserId', companyUserId);

              console.log("Stored companyId:", companyId);
              console.log("Stored companyUserId:", companyUserId);
            }
          
          },
  
          error: (err) => {
            console.log(err)
            console.error("Company fetch failed:", err);
            this.errorMessage = 'Failed to load company details';
          }

        });
      this.router.navigate(['home']);
      },

      error: (err) => {
        console.error('Login failed:', err);

        if (err.status === 401) {
          this.errorMessage = 'Invalid email or password';
        } else if (err.status === 0) {
          this.errorMessage = 'Server not responding';
        } else {
          this.errorMessage = 'Authentication failed. Try again.';
        }
      }

    });
  }
}