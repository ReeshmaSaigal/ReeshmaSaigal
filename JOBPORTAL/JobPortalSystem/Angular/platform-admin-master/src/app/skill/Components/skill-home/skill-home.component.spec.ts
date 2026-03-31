import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SkillHomeComponent } from './skill-home.component';

describe('SkillHomeComponent', () => {
  let component: SkillHomeComponent;
  let fixture: ComponentFixture<SkillHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SkillHomeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SkillHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
