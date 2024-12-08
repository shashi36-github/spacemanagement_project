// src/app/shared/navbar/navbar/navbar.component.ts
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
  imports: [CommonModule],
  standalone: true,
})
export class NavbarComponent {
  constructor(public authService: AuthService, public router: Router) {} // Changed to public
  
  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
