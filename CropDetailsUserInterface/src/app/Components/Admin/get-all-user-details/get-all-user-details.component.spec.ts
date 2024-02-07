import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetAllUserDetailsComponent } from './get-all-user-details.component';

describe('GetAllUserDetailsComponent', () => {
  let component: GetAllUserDetailsComponent;
  let fixture: ComponentFixture<GetAllUserDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GetAllUserDetailsComponent]
    });
    fixture = TestBed.createComponent(GetAllUserDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
