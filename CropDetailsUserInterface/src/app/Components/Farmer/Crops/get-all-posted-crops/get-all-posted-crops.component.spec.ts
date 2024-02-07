import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetAllPostedCropsComponent } from './get-all-posted-crops.component';

describe('GetAllPostedCropsComponent', () => {
  let component: GetAllPostedCropsComponent;
  let fixture: ComponentFixture<GetAllPostedCropsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GetAllPostedCropsComponent]
    });
    fixture = TestBed.createComponent(GetAllPostedCropsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
