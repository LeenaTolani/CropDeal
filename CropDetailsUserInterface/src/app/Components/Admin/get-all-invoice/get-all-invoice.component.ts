import { Component, OnInit } from '@angular/core';
import { Receipt } from 'src/app/Models/Receipt';
import { ReceiptService } from 'src/app/Service/receipt.service';

@Component({
  selector: 'app-get-all-invoice',
  templateUrl: './get-all-invoice.component.html',
  styleUrls: ['./get-all-invoice.component.css']
})
export class GetAllInvoiceComponent implements OnInit{
  allReceipt : Receipt []  = [];

  constructor(private receiptService : ReceiptService ) {}
  ngOnInit(): void {
    this.GetAllReceiptsWithCropAndUser();
  }

  GetAllReceiptsWithCropAndUser(){
    this.receiptService.GetAllReceiptsWithCropAndUser().subscribe({
      next:response =>{ 
        console.log(response);
        this.allReceipt= response;
      },
      error : err =>{console.log(err);}
    });
  }

  //print invoice
  printInvoice(divName: string){ 
    const printContents = document.getElementById(divName)?.innerHTML;
    if (printContents) {
      const originalContents = document.body.innerHTML;
      document.body.innerHTML = printContents;
      window.print();
      window.location.reload();
      document.body.innerHTML = originalContents;
    }
  }

}
