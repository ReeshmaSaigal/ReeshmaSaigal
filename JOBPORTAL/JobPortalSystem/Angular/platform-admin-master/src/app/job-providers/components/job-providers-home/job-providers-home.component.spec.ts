import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobProvidersHomeComponent } from './job-providers-home.component';

describe('JobProvidersHomeComponent', () => {
  let component: JobProvidersHomeComponent;
  let fixture: ComponentFixture<JobProvidersHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JobProvidersHomeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JobProvidersHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
