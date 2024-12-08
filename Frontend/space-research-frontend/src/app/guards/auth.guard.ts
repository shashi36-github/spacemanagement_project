// src/app/guards/auth.guard.ts
import { Injectable } from '@angular/core';
import { CanActivate, Router, UrlTree, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | boolean
    | UrlTree
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree> {
    const isLoggedIn = this.authService.isLoggedIn();
    const expectedRoles = route.data['expectedRoles'] as string[];

    if (!isLoggedIn) {
      return this.router.parseUrl('/login');
    }

    if (expectedRoles && expectedRoles.length > 0) {
      const userRole = this.authService.getUserRole();
      if (expectedRoles.includes(userRole || '')) {
        return true;
      } else {
        // Optionally, navigate to unauthorized page
        return this.router.parseUrl('/unauthorized');
      }
    }

    return true;
  }
}
