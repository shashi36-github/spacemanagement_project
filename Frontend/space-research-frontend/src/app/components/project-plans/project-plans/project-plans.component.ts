// src/app/components/project-plans/project-plans.component.ts
import { Component, OnInit } from '@angular/core';
import { ProjectPlanService } from '../../../services/project-plan.service';
import { MissionService } from '../../../services/mission.service';
import { UserService } from '../../../services/user.service';
import { ProjectPlan } from '../../../models/project-plan.model';
import { Mission } from '../../../models/mission.model';
import { User } from '../../../models/user.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-project-plans',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './project-plans.component.html',
  styleUrls: ['./project-plans.component.css']
})
export class ProjectPlansComponent implements OnInit {
  projectPlans: ProjectPlan[] = [];
  missions: Mission[] = [];
  engineers: User[] = [];
  
  // For Add Project Plan Modal
  isAddPlanModalOpen: boolean = false;
  newProjectPlan: any = {
    title: '',
    description: '',
    missionId: null,
    assignedEngineerId: null
  };
  
  // For Edit Project Plan Modal
  isEditPlanModalOpen: boolean = false;
  editProjectPlan: any = {
    projectPlanId: 0,
    title: '',
    description: '',
    missionId: null,
    assignedEngineerId: null
  };
  
  successMessage: string = '';
  errorMessage: string = '';

  constructor(
    private projectPlanService: ProjectPlanService,
    private missionService: MissionService,
    private userService: UserService
  ) { }

  ngOnInit(): void {
    this.fetchProjectPlans();
    this.fetchMissions();
    this.fetchEngineers();
  }

  // Fetch all project plans
  fetchProjectPlans(): void {
    this.projectPlanService.getAllProjectPlans().subscribe({
      next: (data) => this.projectPlans = data,
      error: (err) => {
        this.errorMessage = 'Failed to fetch project plans.';
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

  // Fetch all engineers
  fetchEngineers(): void {
    this.userService.getAllUsers().subscribe({
      next: (data) => {
        this.engineers = data.filter(user => user.role === 'Engineer');
      },
      error: (err) => {
        this.errorMessage = 'Failed to fetch engineers.';
        console.error(err);
      }
    });
  }

  // Get Mission Name by ID
  getMissionName(missionId: number): string {
    const mission = this.missions.find(m => m.missionId === missionId);
    return mission ? mission.name : '';
  }

  // Get Engineer Name by ID
  getEngineerName(engineerId: number): string {
    const engineer = this.engineers.find(e => e.userId === engineerId);
    return engineer ? engineer.username : '';
  }

  // Open Add Project Plan Modal
  openAddPlanModal(): void {
    this.isAddPlanModalOpen = true;
    this.newProjectPlan = {
      title: '',
      description: '',
      missionId: null,
      assignedEngineerId: null
    };
    this.errorMessage = '';
    this.successMessage = '';
  }

  // Close Add Project Plan Modal
  closeAddPlanModal(): void {
    this.isAddPlanModalOpen = false;
  }

  // Add Project Plan
  addProjectPlan(): void {
    const planToAdd: ProjectPlan = {
      projectPlanId: 0, // Backend assigns ID
      title: this.newProjectPlan.title,
      description: this.newProjectPlan.description,
      missionId: this.newProjectPlan.missionId,
      assignedEngineerId: this.newProjectPlan.assignedEngineerId
      // Add other fields if necessary
    };

    this.projectPlanService.createProjectPlan(planToAdd).subscribe({
      next: (plan) => {
        this.successMessage = 'Project plan added successfully.';
        this.closeAddPlanModal();
        this.fetchProjectPlans();
      },
      error: (err) => {
        this.errorMessage = 'Failed to add project plan.';
        console.error(err);
      }
    });
  }

  // Open Edit Project Plan Modal
  openEditPlanModal(plan: ProjectPlan): void {
    this.isEditPlanModalOpen = true;
    this.editProjectPlan = { ...plan };
    this.errorMessage = '';
    this.successMessage = '';
  }

  // Close Edit Project Plan Modal
  closeEditPlanModal(): void {
    this.isEditPlanModalOpen = false;
  }

  // Update Project Plan
  updateProjectPlan(): void {
    const updatedPlan: ProjectPlan = {
      projectPlanId: this.editProjectPlan.projectPlanId,
      title: this.editProjectPlan.title,
      description: this.editProjectPlan.description,
      missionId: this.editProjectPlan.missionId,
      assignedEngineerId: this.editProjectPlan.assignedEngineerId
      // Add other fields if necessary
    };

    this.projectPlanService.updateProjectPlan(updatedPlan.projectPlanId, updatedPlan).subscribe({
      next: () => {
        this.successMessage = 'Project plan updated successfully.';
        this.closeEditPlanModal();
        this.fetchProjectPlans();
      },
      error: (err) => {
        this.errorMessage = 'Failed to update project plan.';
        console.error(err);
      }
    });
  }

  // Delete Project Plan
  deleteProjectPlan(planId: number): void {
    if (confirm('Are you sure you want to delete this project plan?')) {
      this.projectPlanService.deleteProjectPlan(planId).subscribe({
        next: () => {
          this.successMessage = 'Project plan deleted successfully.';
          this.fetchProjectPlans();
        },
        error: (err) => {
          this.errorMessage = 'Failed to delete project plan.';
          console.error(err);
        }
      });
    }
  }
}
