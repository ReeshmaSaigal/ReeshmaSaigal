import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobseekerHeaderComponent } from './jobseeker-header.component';

describe('JobseekerHeaderComponent', () => {
  let component: JobseekerHeaderComponent;
  let fixture: ComponentFixture<JobseekerHeaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JobseekerHeaderComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JobseekerHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
