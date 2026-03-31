import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewRegistrationHomeComponent } from './new-registration-home.component';

describe('NewRegistrationHomeComponent', () => {
  let component: NewRegistrationHomeComponent;
  let fixture: ComponentFixture<NewRegistrationHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewRegistrationHomeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewRegistrationHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
