import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectPlansComponent } from './project-plans.component';

describe('ProjectPlansComponent', () => {
  let component: ProjectPlansComponent;
  let fixture: ComponentFixture<ProjectPlansComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProjectPlansComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProjectPlansComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
