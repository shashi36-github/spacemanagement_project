// src/app/services/scientific-data.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ScientificData } from '../models/scientific-data.model';

@Injectable({
  providedIn: 'root'
})
export class ScientificDataService {
  private apiUrl = 'https://localhost:5001/api/scientificdata'; // Replace with your backend URL

  constructor(private http: HttpClient) { }

  // Get all scientific data
  getAllScientificDatas(): Observable<ScientificData[]> {
    return this.http.get<ScientificData[]>(`${this.apiUrl}`);
  }

  // Get scientific data by ID
  getScientificDataById(id: number): Observable<ScientificData> {
    return this.http.get<ScientificData>(`${this.apiUrl}/${id}`);
  }

  // Create a new scientific data entry
  createScientificData(data: ScientificData): Observable<ScientificData> {
    return this.http.post<ScientificData>(`${this.apiUrl}`, data);
  }

  // Update an existing scientific data entry
  updateScientificData(id: number, data: ScientificData): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, data);
  }

  // Delete a scientific data entry
  deleteScientificData(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  // Get scientific data by mission
  getScientificDataByMission(missionId: number): Observable<ScientificData[]> {
    return this.http.get<ScientificData[]>(`${this.apiUrl}/mission/${missionId}`);
  }

  // Get scientific data by researcher
  getScientificDataByResearcher(researcherId: number): Observable<ScientificData[]> {
    return this.http.get<ScientificData[]>(`${this.apiUrl}/researcher/${researcherId}`);
  }
}
