// src/app/models/equipment.model.ts
export interface Equipment {
    equipmentId: number;
    name: string;
    description: string;
    assignedMissionId?: number; // Optional, as equipment may not be assigned initially
    // Add other fields as necessary
  }
  