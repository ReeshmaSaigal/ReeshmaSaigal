import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationSeekerProfessionalInfoComponent } from './application-seeker-professional-info.component';

describe('ApplicationSeekerProfessionalInfoComponent', () => {
  let component: ApplicationSeekerProfessionalInfoComponent;
  let fixture: ComponentFixture<ApplicationSeekerProfessionalInfoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ApplicationSeekerProfessionalInfoComponent]
    });
    fixture = TestBed.createComponent(ApplicationSeekerProfessionalInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
