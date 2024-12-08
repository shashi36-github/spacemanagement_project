// src/app/models/user.model.ts
export interface User {
    userId: number;
    username: string;
    email: string;
    role: string;
    isActive: boolean;
    password?: string; // Optional for password handling
  }
  