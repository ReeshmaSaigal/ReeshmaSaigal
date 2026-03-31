import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationHomeComponent } from './application-home.component';

describe('ApplicationHomeComponent', () => {
  let component: ApplicationHomeComponent;
  let fixture: ComponentFixture<ApplicationHomeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ApplicationHomeComponent]
    });
    fixture = TestBed.createComponent(ApplicationHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
