import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetBankDetailsComponent } from './get-bank-details.component';

describe('GetBankDetailsComponent', () => {
  let component: GetBankDetailsComponent;
  let fixture: ComponentFixture<GetBankDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GetBankDetailsComponent]
    });
    fixture = TestBed.createComponent(GetBankDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
