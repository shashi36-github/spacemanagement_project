import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CostManagementsComponent } from './cost-managements.component';

describe('CostManagementsComponent', () => {
  let component: CostManagementsComponent;
  let fixture: ComponentFixture<CostManagementsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CostManagementsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CostManagementsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
