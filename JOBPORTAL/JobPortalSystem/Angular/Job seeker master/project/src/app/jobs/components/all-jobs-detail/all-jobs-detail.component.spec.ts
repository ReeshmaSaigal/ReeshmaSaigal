import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllJobsDetailComponent } from './all-jobs-detail.component';

describe('AllJobsDetailComponent', () => {
  let component: AllJobsDetailComponent;
  let fixture: ComponentFixture<AllJobsDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllJobsDetailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllJobsDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
