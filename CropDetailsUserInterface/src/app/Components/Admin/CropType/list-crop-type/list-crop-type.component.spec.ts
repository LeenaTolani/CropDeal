import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListCropTypeComponent } from './list-crop-type.component';

describe('ListCropTypeComponent', () => {
  let component: ListCropTypeComponent;
  let fixture: ComponentFixture<ListCropTypeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListCropTypeComponent]
    });
    fixture = TestBed.createComponent(ListCropTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
