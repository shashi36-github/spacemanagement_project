// src/app/components/users/users.component.ts
import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { User } from '../../../models/user.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  users: User[] = [];
  
  // For Add User Modal
  isAddUserModalOpen: boolean = false;
  newUser: any = {
    username: '',
    email: '',
    role: '',
    password: ''
  };
  
  // For Edit User Modal
  isEditUserModalOpen: boolean = false;
  editUser: any = {
    userId: 0,
    username: '',
    email: '',
    role: '',
    password: ''
  };
  
  successMessage: string = '';
  errorMessage: string = '';

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.fetchUsers();
  }

  // Fetch all users
  fetchUsers(): void {
    this.userService.getAllUsers().subscribe({
      next: (data) => this.users = data,
      error: (err) => {
        this.errorMessage = 'Failed to fetch users.';
        console.error(err);
      }
    });
  }

  // Open Add User Modal
  openAddUserModal(): void {
    this.isAddUserModalOpen = true;
    this.newUser = {
      username: '',
      email: '',
      role: '',
      password: ''
    };
    this.errorMessage = '';
    this.successMessage = '';
  }

  // Close Add User Modal
  closeAddUserModal(): void {
    this.isAddUserModalOpen = false;
  }

  // Add User
  addUser(): void {
    const userToAdd: User = {
      userId: 0, // Backend will assign ID
      username: this.newUser.username,
      email: this.newUser.email,
      role: this.newUser.role,
      isActive: true
      // Note: Password handling should be managed securely
    };

    this.userService.createUser(userToAdd).subscribe({
      next: (user) => {
        this.successMessage = 'User added successfully.';
        this.closeAddUserModal();
        this.fetchUsers();
      },
      error: (err) => {
        this.errorMessage = 'Failed to add user.';
        console.error(err);
      }
    });
  }

  // Open Edit User Modal
  openEditUserModal(user: User): void {
    this.isEditUserModalOpen = true;
    this.editUser = { ...user, password: '' }; // Initialize with existing user data
    this.errorMessage = '';
    this.successMessage = '';
  }

  // Close Edit User Modal
  closeEditUserModal(): void {
    this.isEditUserModalOpen = false;
  }

  // Update User
  updateUser(): void {
    const updatedUser: User = {
      userId: this.editUser.userId,
      username: this.editUser.username,
      email: this.editUser.email,
      role: this.editUser.role,
      isActive: this.editUser.isActive
      // Note: Password handling should be managed securely
    };

    this.userService.updateUser(updatedUser.userId, updatedUser).subscribe({
      next: () => {
        this.successMessage = 'User updated successfully.';
        this.closeEditUserModal();
        this.fetchUsers();
      },
      error: (err) => {
        this.errorMessage = 'Failed to update user.';
        console.error(err);
      }
    });
  }

  // Delete User
  deleteUser(userId: number): void {
    if (confirm('Are you sure you want to delete this user?')) {
      this.userService.deleteUser(userId).subscribe({
        next: () => {
          this.successMessage = 'User deleted successfully.';
          this.fetchUsers();
        },
        error: (err) => {
          this.errorMessage = 'Failed to delete user.';
          console.error(err);
        }
      });
    }
  }
}
