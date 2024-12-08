// src/app/services/mission.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Mission } from '../models/mission.model';

@Injectable({
  providedIn: 'root'
})
export class MissionService {
  private apiUrl = 'https://localhost:7180/api/missions';

  constructor(private http: HttpClient) { }

  getAllMissions(): Observable<Mission[]> {
    return this.http.get<Mission[]>(`${this.apiUrl}`);
  }

  getMissionById(id: number): Observable<Mission> {
    return this.http.get<Mission>(`${this.apiUrl}/${id}`);
  }

  createMission(mission: Mission): Observable<Mission> {
    return this.http.post<Mission>(`${this.apiUrl}`, mission);
  }

  updateMission(id: number, mission: Mission): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, mission);
  }

  deleteMission(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  getMissionsByDirector(directorId: number): Observable<Mission[]> {
    return this.http.get<Mission[]>(`${this.apiUrl}/director/${directorId}`);
  }
}
