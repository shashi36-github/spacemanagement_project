import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SafetyLogsComponent } from './safety-logs.component';

describe('SafetyLogsComponent', () => {
  let component: SafetyLogsComponent;
  let fixture: ComponentFixture<SafetyLogsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SafetyLogsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SafetyLogsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
