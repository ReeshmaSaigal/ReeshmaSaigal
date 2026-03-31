import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthServiceService } from '../auth/service/auth-service.service';

@Injectable({
  providedIn: 'root' // Use providedIn: 'root' to provide the guard application-wide
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router,private authService:AuthServiceService) { }

  canActivate(): boolean {
    if (this.authService.isAuthenticated()) {
      return true;
    } else {
      this.router.navigate(['/login']); // Redirect to login if not authenticated
      return false;
    }
  }
}

