import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetAllInvoiceComponent } from './get-all-invoice.component';

describe('GetAllInvoiceComponent', () => {
  let component: GetAllInvoiceComponent;
  let fixture: ComponentFixture<GetAllInvoiceComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GetAllInvoiceComponent]
    });
    fixture = TestBed.createComponent(GetAllInvoiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
