import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlljobsNavbarComponent } from './alljobs-navbar.component';

describe('AlljobsNavbarComponent', () => {
  let component: AlljobsNavbarComponent;
  let fixture: ComponentFixture<AlljobsNavbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AlljobsNavbarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AlljobsNavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
