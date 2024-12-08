import { User } from "./user.model";

// src/app/models/mission.model.ts
export interface Mission {
    missionId: number;
    name: string;
    description: string;
    directorId: number;
    director?: User; // Optional, populated from backend
    // Add other fields as necessary
  }
  