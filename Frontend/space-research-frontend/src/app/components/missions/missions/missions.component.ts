// src/app/components/missions/missions.component.ts
import { Component, OnInit } from '@angular/core';
import { MissionService } from '../../../services/mission.service';
import { UserService } from '../../../services/user.service';
import { Mission } from '../../../models/mission.model';
import { User } from '../../../models/user.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-missions',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './missions.component.html',
  styleUrls: ['./missions.component.css']
})
export class MissionsComponent implements OnInit {
  missions: Mission[] = [];
  directors: User[] = [];
  
  // For Add Mission Modal
  isAddMissionModalOpen: boolean = false;
  newMission: any = {
    name: '',
    description: '',
    directorId: ''
  };
  
  // For Edit Mission Modal
  isEditMissionModalOpen: boolean = false;
  editMission: any = {
    missionId: 0,
    name: '',
    description: '',
    directorId: ''
  };
  
  successMessage: string = '';
  errorMessage: string = '';

  constructor(private missionService: MissionService, private userService: UserService) { }

  ngOnInit(): void {
    this.fetchMissions();
    this.fetchDirectors();
  }

  // Fetch all missions
  fetchMissions(): void {
    this.missionService.getAllMissions().subscribe({
      next: (data) => this.missions = data,
      error: (err) => {
        this.errorMessage = 'Failed to fetch missions.';
        console.error(err);
      }
    });
  }

  // Fetch all directors
  fetchDirectors(): void {
    this.userService.getAllUsers().subscribe({
      next: (data) => {
        this.directors = data.filter(user => user.role === 'MissionDirector');
      },
      error: (err) => {
        this.errorMessage = 'Failed to fetch directors.';
        console.error(err);
      }
    });
  }

  // Open Add Mission Modal
  openAddMissionModal(): void {
    this.isAddMissionModalOpen = true;
    this.newMission = {
      name: '',
      description: '',
      directorId: ''
    };
    this.errorMessage = '';
    this.successMessage = '';
  }

  // Close Add Mission Modal
  closeAddMissionModal(): void {
    this.isAddMissionModalOpen = false;
  }

  // Add Mission
  addMission(): void {
    const missionToAdd: Mission = {
      missionId: 0, // Backend assigns ID
      name: this.newMission.name,
      description: this.newMission.description,
      directorId: this.newMission.directorId,
      // Add other fields if necessary
    };

    this.missionService.createMission(missionToAdd).subscribe({
      next: (mission) => {
        this.successMessage = 'Mission added successfully.';
        this.closeAddMissionModal();
        this.fetchMissions();
      },
      error: (err) => {
        this.errorMessage = 'Failed to add mission.';
        console.error(err);
      }
    });
  }

  // Open Edit Mission Modal
  openEditMissionModal(mission: Mission): void {
    this.isEditMissionModalOpen = true;
    this.editMission = { ...mission };
    this.errorMessage = '';
    this.successMessage = '';
  }

  // Close Edit Mission Modal
  closeEditMissionModal(): void {
    this.isEditMissionModalOpen = false;
  }

  // Update Mission
  updateMission(): void {
    const updatedMission: Mission = {
      missionId: this.editMission.missionId,
      name: this.editMission.name,
      description: this.editMission.description,
      directorId: this.editMission.directorId,
      // Add other fields if necessary
    };

    this.missionService.updateMission(updatedMission.missionId, updatedMission).subscribe({
      next: () => {
        this.successMessage = 'Mission updated successfully.';
        this.closeEditMissionModal();
        this.fetchMissions();
      },
      error: (err) => {
        this.errorMessage = 'Failed to update mission.';
        console.error(err);
      }
    });
  }

  // Delete Mission
  deleteMission(missionId: number): void {
    if (confirm('Are you sure you want to delete this mission?')) {
      this.missionService.deleteMission(missionId).subscribe({
        next: () => {
          this.successMessage = 'Mission deleted successfully.';
          this.fetchMissions();
        },
        error: (err) => {
          this.errorMessage = 'Failed to delete mission.';
          console.error(err);
        }
      });
    }
  }
}
