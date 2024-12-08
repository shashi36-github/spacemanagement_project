// src/app/components/equipments/equipments.component.ts
import { Component, OnInit } from '@angular/core';
import { EquipmentService } from '../../../services/equipment.service';
import { MissionService } from '../../../services/mission.service';
import { Equipment } from '../../../models/equipment.model';
import { Mission } from '../../../models/mission.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-equipments',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './equipments.component.html',
  styleUrls: ['./equipments.component.css']
})
export class EquipmentsComponent implements OnInit {
  equipments: Equipment[] = [];
  missions: Mission[] = [];
  
  // For Add Equipment Modal
  isAddEquipmentModalOpen: boolean = false;
  newEquipment: any = {
    name: '',
    description: '',
    assignedMissionId: null
  };
  
  
  // For Edit Equipment Modal
  isEditEquipmentModalOpen: boolean = false;
  editEquipment: any = {
    equipmentId: 0,
    name: '',
    description: '',
    assignedMissionId: null
  };
  
  successMessage: string = '';
  errorMessage: string = '';

  constructor(private equipmentService: EquipmentService, private missionService: MissionService) { }

  ngOnInit(): void {
    this.fetchEquipments();
    this.fetchMissions();
  }

  // Fetch all equipments
  fetchEquipments(): void {
    this.equipmentService.getAllEquipments().subscribe({
      next: (data) => this.equipments = data,
      error: (err) => {
        this.errorMessage = 'Failed to fetch equipments.';
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

  // Get Mission Name by ID
  getMissionName(missionId?: number): string {
    if (!missionId) return '';
    const mission = this.missions.find(m => m.missionId === missionId);
    return mission ? mission.name : '';
  }

  // Open Add Equipment Modal
  openAddEquipmentModal(): void {
    this.isAddEquipmentModalOpen = true;
    this.newEquipment = {
      name: '',
      description: '',
      assignedMissionId: null
    };
    this.errorMessage = '';
    this.successMessage = '';
  }

  // Close Add Equipment Modal
  closeAddEquipmentModal(): void {
    this.isAddEquipmentModalOpen = false;
  }

  // Add Equipment
  addEquipment(): void {
    const equipmentToAdd: Equipment = {
      equipmentId: 0, // Backend assigns ID
      name: this.newEquipment.name,
      description: this.newEquipment.description,
      assignedMissionId: this.newEquipment.assignedMissionId
      // Add other fields if necessary
    };

    this.equipmentService.createEquipment(equipmentToAdd).subscribe({
      next: (equipment) => {
        this.successMessage = 'Equipment added successfully.';
        this.closeAddEquipmentModal();
        this.fetchEquipments();
      },
      error: (err) => {
        this.errorMessage = 'Failed to add equipment.';
        console.error(err);
      }
    });
  }

  // Open Edit Equipment Modal
  openEditEquipmentModal(equipment: Equipment): void {
    this.isEditEquipmentModalOpen = true;
    this.editEquipment = { ...equipment };
    this.errorMessage = '';
    this.successMessage = '';
  }

  // Close Edit Equipment Modal
  closeEditEquipmentModal(): void {
    this.isEditEquipmentModalOpen = false;
  }

  // Update Equipment
  updateEquipment(): void {
    const updatedEquipment: Equipment = {
      equipmentId: this.editEquipment.equipmentId,
      name: this.editEquipment.name,
      description: this.editEquipment.description,
      assignedMissionId: this.editEquipment.assignedMissionId
      // Add other fields if necessary
    };

    this.equipmentService.updateEquipment(updatedEquipment.equipmentId, updatedEquipment).subscribe({
      next: () => {
        this.successMessage = 'Equipment updated successfully.';
        this.closeEditEquipmentModal();
        this.fetchEquipments();
      },
      error: (err) => {
        this.errorMessage = 'Failed to update equipment.';
        console.error(err);
      }
    });
  }

  // Delete Equipment
  deleteEquipment(equipmentId: number): void {
    if (confirm('Are you sure you want to delete this equipment?')) {
      this.equipmentService.deleteEquipment(equipmentId).subscribe({
        next: () => {
          this.successMessage = 'Equipment deleted successfully.';
          this.fetchEquipments();
        },
        error: (err) => {
          this.errorMessage = 'Failed to delete equipment.';
          console.error(err);
        }
      });
    }
  }
}
