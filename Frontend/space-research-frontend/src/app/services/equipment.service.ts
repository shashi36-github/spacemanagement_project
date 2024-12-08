// src/app/services/equipment.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Equipment } from '../models/equipment.model';

@Injectable({
  providedIn: 'root'
})
export class EquipmentService {
  private apiUrl = 'https://localhost:7108/api/equipments'; // Replace with your backend URL

  constructor(private http: HttpClient) { }

  // Get all equipments
  getAllEquipments(): Observable<Equipment[]> {
    return this.http.get<Equipment[]>(`${this.apiUrl}`);
  }

  // Get equipment by ID
  getEquipmentById(id: number): Observable<Equipment> {
    return this.http.get<Equipment>(`${this.apiUrl}/${id}`);
  }

  // Create a new equipment
  createEquipment(equipment: Equipment): Observable<Equipment> {
    return this.http.post<Equipment>(`${this.apiUrl}`, equipment);
  }

  // Update an existing equipment
  updateEquipment(id: number, equipment: Equipment): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, equipment);
  }

  // Delete an equipment
  deleteEquipment(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  // Get equipments by mission
  getEquipmentsByMission(missionId: number): Observable<Equipment[]> {
    return this.http.get<Equipment[]>(`${this.apiUrl}/mission/${missionId}`);
  }
}
