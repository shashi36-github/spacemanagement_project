// src/app/components/scientific-data/scientific-data.component.ts
import { Component, OnInit } from '@angular/core';
import { ScientificDataService } from '../../../services/scientific-data.service';
import { MissionService } from '../../../services/mission.service';
import { UserService } from '../../../services/user.service';
import { ScientificData } from '../../../models/scientific-data.model';
import { Mission } from '../../../models/mission.model';
import { User } from '../../../models/user.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-scientific-data',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './scientific-data.component.html',
  styleUrls: ['./scientific-data.component.css',]
})
export class ScientificDataComponent implements OnInit {
  scientificDatas: ScientificData[] = [];
  missions: Mission[] = [];
  researchers: User[] = [];
  
  // For Add Scientific Data Modal
  isAddDataModalOpen: boolean = false;
  newScientificData: any = {
    title: '',
    description: '',
    missionId: null,
    researcherId: null
  };
  
  // For Edit Scientific Data Modal
  isEditDataModalOpen: boolean = false;
  editScientificData: any = {
    scientificDataId: 0,
    title: '',
    description: '',
    missionId: null,
    researcherId: null
  };
  
  successMessage: string = '';
  errorMessage: string = '';

  constructor(
    private scientificDataService: ScientificDataService,
    private missionService: MissionService,
    private userService: UserService
  ) { }

  ngOnInit(): void {
    this.fetchScientificDatas();
    this.fetchMissions();
    this.fetchResearchers();
  }

  // Fetch all scientific data
  fetchScientificDatas(): void {
    this.scientificDataService.getAllScientificDatas().subscribe({
      next: (data) => this.scientificDatas = data,
      error: (err) => {
        this.errorMessage = 'Failed to fetch scientific data.';
        console.error(err);
      }
    });
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

  // Fetch all researchers
  fetchResearchers(): void {
    this.userService.getAllUsers().subscribe({
      next: (data) => {
        this.researchers = data.filter(user => user.role === 'Researcher');
      },
      error: (err) => {
        this.errorMessage = 'Failed to fetch researchers.';
        console.error(err);
      }
    });
  }

  // Get Mission Name by ID
  getMissionName(missionId: number): string {
    const mission = this.missions.find(m => m.missionId === missionId);
    return mission ? mission.name : '';
  }

  // Get Researcher Name by ID
  getResearcherName(researcherId: number): string {
    const researcher = this.researchers.find(r => r.userId === researcherId);
    return researcher ? researcher.username : '';
  }

  // Open Add Scientific Data Modal
  openAddDataModal(): void {
    this.isAddDataModalOpen = true;
    this.newScientificData = {
      title: '',
      description: '',
      missionId: null,
      researcherId: null
    };
    this.errorMessage = '';
    this.successMessage = '';
  }

  // Close Add Scientific Data Modal
  closeAddDataModal(): void {
    this.isAddDataModalOpen = false;
  }

  // Add Scientific Data
  addScientificData(): void {
    const dataToAdd: ScientificData = {
      scientificDataId: 0, // Backend assigns ID
      title: this.newScientificData.title,
      description: this.newScientificData.description,
      missionId: this.newScientificData.missionId,
      researcherId: this.newScientificData.researcherId
      // Add other fields if necessary
    };

    this.scientificDataService.createScientificData(dataToAdd).subscribe({
      next: (data) => {
        this.successMessage = 'Scientific data added successfully.';
        this.closeAddDataModal();
        this.fetchScientificDatas();
      },
      error: (err) => {
        this.errorMessage = 'Failed to add scientific data.';
        console.error(err);
      }
    });
  }

  // Open Edit Scientific Data Modal
  openEditDataModal(data: ScientificData): void {
    this.isEditDataModalOpen = true;
    this.editScientificData = { ...data };
    this.errorMessage = '';
    this.successMessage = '';
  }

  // Close Edit Scientific Data Modal
  closeEditDataModal(): void {
    this.isEditDataModalOpen = false;
  }

  // Update Scientific Data
  updateScientificData(): void {
    const updatedData: ScientificData = {
      scientificDataId: this.editScientificData.scientificDataId,
      title: this.editScientificData.title,
      description: this.editScientificData.description,
      missionId: this.editScientificData.missionId,
      researcherId: this.editScientificData.researcherId
      // Add other fields if necessary
    };

    this.scientificDataService.updateScientificData(updatedData.scientificDataId, updatedData).subscribe({
      next: () => {
        this.successMessage = 'Scientific data updated successfully.';
        this.closeEditDataModal();
        this.fetchScientificDatas();
      },
      error: (err) => {
        this.errorMessage = 'Failed to update scientific data.';
        console.error(err);
      }
    });
  }

  // Delete Scientific Data
  deleteScientificData(dataId: number): void {
    if (confirm('Are you sure you want to delete this scientific data?')) {
      this.scientificDataService.deleteScientificData(dataId).subscribe({
        next: () => {
          this.successMessage = 'Scientific data deleted successfully.';
          this.fetchScientificDatas();
        },
        error: (err) => {
          this.errorMessage = 'Failed to delete scientific data.';
          console.error(err);
        }
      });
    }
  }
}
