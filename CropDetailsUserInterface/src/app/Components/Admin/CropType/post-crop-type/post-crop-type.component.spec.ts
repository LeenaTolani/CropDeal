import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostCropTypeComponent } from './post-crop-type.component';

describe('PostCropTypeComponent', () => {
  let component: PostCropTypeComponent;
  let fixture: ComponentFixture<PostCropTypeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PostCropTypeComponent]
    });
    fixture = TestBed.createComponent(PostCropTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
