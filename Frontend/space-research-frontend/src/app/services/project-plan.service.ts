// src/app/services/project-plan.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProjectPlan } from '../models/project-plan.model';

@Injectable({
  providedIn: 'root'
})
export class ProjectPlanService {
  private apiUrl = 'https://localhost:7108/api/projectplans'; // Replace with your backend URL

  constructor(private http: HttpClient) { }

  // Get all project plans
  getAllProjectPlans(): Observable<ProjectPlan[]> {
    return this.http.get<ProjectPlan[]>(`${this.apiUrl}`);
  }

  // Get project plan by ID
  getProjectPlanById(id: number): Observable<ProjectPlan> {
    return this.http.get<ProjectPlan>(`${this.apiUrl}/${id}`);
  }

  // Create a new project plan
  createProjectPlan(plan: ProjectPlan): Observable<ProjectPlan> {
    return this.http.post<ProjectPlan>(`${this.apiUrl}`, plan);
  }

  // Update an existing project plan
  updateProjectPlan(id: number, plan: ProjectPlan): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, plan);
  }

  // Delete a project plan
  deleteProjectPlan(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  // Get project plans by mission
  getProjectPlansByMission(missionId: number): Observable<ProjectPlan[]> {
    return this.http.get<ProjectPlan[]>(`${this.apiUrl}/mission/${missionId}`);
  }

  // Get project plans by engineer
  getProjectPlansByEngineer(engineerId: number): Observable<ProjectPlan[]> {
    return this.http.get<ProjectPlan[]>(`${this.apiUrl}/engineer/${engineerId}`);
  }
}
