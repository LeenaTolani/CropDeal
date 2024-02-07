import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCropTypeComponent } from './edit-crop-type.component';

describe('EditCropTypeComponent', () => {
  let component: EditCropTypeComponent;
  let fixture: ComponentFixture<EditCropTypeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditCropTypeComponent]
    });
    fixture = TestBed.createComponent(EditCropTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
