// src/app/services/auth.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { User } from '../models/user.model';
import jwt_decode from 'jwt-decode';

interface DecodedToken {
  nameid: string;
  unique_name: string;
  role: string;
  exp: number;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7108/api/Auth'; // Replace with your backend URL

  constructor(private http: HttpClient) { }

  // Register a new user
  register(user: User): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/Register`, user);
  }

  // Login user
  login(username: string, password: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/Login`, { username, password })
      .pipe(
        tap(response => {
          if (response && response.token) {
            localStorage.setItem('jwtToken', response.token);
          }
        })
      );
  }

  // Logout user
  logout(): void {
    localStorage.removeItem('jwtToken');
  }

  // Check if user is logged in
  isLoggedIn(): boolean {
    const token = this.getToken();
    if (!token) return false;

    const decoded: DecodedToken = jwt_decode(token);
    const currentTime = Date.now() / 1000;

    return decoded.exp > currentTime;
  }

  // Get JWT Token
  getToken(): string | null {
    if (typeof window !== 'undefined') {
      return localStorage.getItem('token'); // Only access localStorage if window is defined
    }
    return null; // Or handle this as per your application logic for SSR
  }

  // Get User Role
  getUserRole(): string | null {
    const token = this.getToken();
    if (!token) return null;

    const decoded: DecodedToken = jwt_decode(token);
    return decoded.role;
  }

  // Get User ID
  getUserId(): number | null {
    const token = this.getToken();
    if (!token) return null;

    const decoded: DecodedToken = jwt_decode(token);
    return parseInt(decoded.nameid);
  }
}
