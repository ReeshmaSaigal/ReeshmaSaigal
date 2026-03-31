import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProviderProfessionalInfoComponent } from './provider-professional-info.component';

describe('ProviderProfessionalInfoComponent', () => {
  let component: ProviderProfessionalInfoComponent;
  let fixture: ComponentFixture<ProviderProfessionalInfoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProviderProfessionalInfoComponent]
    });
    fixture = TestBed.createComponent(ProviderProfessionalInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
