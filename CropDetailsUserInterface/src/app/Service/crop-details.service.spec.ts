import { TestBed } from '@angular/core/testing';

import { CropDetailsService } from './crop-details.service';

describe('CropDetailsService', () => {
  let service: CropDetailsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CropDetailsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
