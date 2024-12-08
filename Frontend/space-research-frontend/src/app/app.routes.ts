// src/app/app-routing.ts
import { Routes } from '@angular/router';
import { UsersComponent } from './components/users/users/users.component';
import { MissionsComponent } from './components/missions/missions/missions.component';
import { EquipmentsComponent } from './components/equipments/equipments/equipments.component';
import { ScientificDataComponent } from './components/scientific-data/scientific-data/scientific-data.component';
import { ProjectPlansComponent } from './components/project-plans/project-plans/project-plans.component';
import { SafetyLogsComponent } from './components/safety-logs/safety-logs/safety-logs.component';
import { MissionPerformancesComponent } from './components/mission-performances/mission-performances/mission-performances.component';
import { CostManagementsComponent } from './components/cost-managements/cost-managements/cost-managements.component';
import { EnvironmentalDataComponent } from './components/environmental-data/environmental-data/environmental-data.component';
import { ReportsComponent } from './components/reports/reports/reports.component';
import { NotificationsComponent } from './components/notifications/notifications/notifications.component';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { AuthGuard } from './guards/auth.guard';
import { UnauthorizedComponent } from './components/auth/unauthorized/unauthorized.component';


export const appRoutes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'unauthorized', component: UnauthorizedComponent },

    // Protected routes
    { path: 'users', component: UsersComponent, canActivate: [AuthGuard], data: { expectedRoles: ['Admin', 'MissionDirector'] } },
    { path: 'missions', component: MissionsComponent, canActivate: [AuthGuard], data: { expectedRoles: ['Admin', 'MissionDirector'] } },
    { path: 'equipments', component: EquipmentsComponent, canActivate: [AuthGuard] ,data: { expectedRoles: ['Admin', 'MissionDirector'] }},
    { path: 'scientific-data', component: ScientificDataComponent, canActivate: [AuthGuard] ,data: { expectedRoles: ['Admin', 'MissionDirector'] }},
    { path: 'project-plans', component: ProjectPlansComponent, canActivate: [AuthGuard],data: { expectedRoles: ['Admin', 'MissionDirector'] } },
    { path: 'safety-logs', component: SafetyLogsComponent, canActivate: [AuthGuard] ,data: { expectedRoles: ['Admin', 'MissionDirector'] }},
    { path: 'mission-performances', component: MissionPerformancesComponent, canActivate: [AuthGuard],data: { expectedRoles: ['Admin', 'MissionDirector'] } },
    { path: 'cost-managements', component: CostManagementsComponent, canActivate: [AuthGuard] ,data: { expectedRoles: ['Admin', 'MissionDirector'] }},
    { path: 'environmental-data', component: EnvironmentalDataComponent, canActivate: [AuthGuard] ,data: { expectedRoles: ['Admin', 'MissionDirector'] }},
    { path: 'reports', component: ReportsComponent, canActivate: [AuthGuard],data: { expectedRoles: ['Admin', 'MissionDirector'] } },
    { path: 'notifications', component: NotificationsComponent, canActivate: [AuthGuard],data: { expectedRoles: ['Admin', 'MissionDirector'] } },
    
    { path: '', redirectTo: '/users', pathMatch: 'full' }, // Default route
    { path: '**', redirectTo: '/users' } // Wildcard route
  ];