import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchCropsByNameComponent } from './search-crops-by-name.component';

describe('SearchCropsByNameComponent', () => {
  let component: SearchCropsByNameComponent;
  let fixture: ComponentFixture<SearchCropsByNameComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SearchCropsByNameComponent]
    });
    fixture = TestBed.createComponent(SearchCropsByNameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
