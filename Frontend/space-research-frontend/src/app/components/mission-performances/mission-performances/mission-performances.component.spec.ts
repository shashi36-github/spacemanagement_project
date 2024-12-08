import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MissionPerformancesComponent } from './mission-performances.component';

describe('MissionPerformancesComponent', () => {
  let component: MissionPerformancesComponent;
  let fixture: ComponentFixture<MissionPerformancesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MissionPerformancesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MissionPerformancesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
