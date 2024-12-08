import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScientificDataComponent } from './scientific-data.component';

describe('ScientificDataComponent', () => {
  let component: ScientificDataComponent;
  let fixture: ComponentFixture<ScientificDataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ScientificDataComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ScientificDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
