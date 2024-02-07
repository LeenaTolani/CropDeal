import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewAllCropsComponent } from './view-all-crops.component';

describe('ViewAllCropsComponent', () => {
  let component: ViewAllCropsComponent;
  let fixture: ComponentFixture<ViewAllCropsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewAllCropsComponent]
    });
    fixture = TestBed.createComponent(ViewAllCropsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
