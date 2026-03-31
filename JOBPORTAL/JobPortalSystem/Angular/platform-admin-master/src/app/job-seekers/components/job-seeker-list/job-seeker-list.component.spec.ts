import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobSeekerListComponent } from './job-seeker-list.component';

describe('JobSeekerListComponent', () => {
  let component: JobSeekerListComponent;
  let fixture: ComponentFixture<JobSeekerListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JobSeekerListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JobSeekerListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
