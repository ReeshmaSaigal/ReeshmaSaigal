import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InterviewHeaderComponent } from './interview-header.component';

describe('InterviewHeaderComponent', () => {
  let component: InterviewHeaderComponent;
  let fixture: ComponentFixture<InterviewHeaderComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InterviewHeaderComponent]
    });
    fixture = TestBed.createComponent(InterviewHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
