import { Component, OnInit } from '@angular/core';
import { Receipt } from 'src/app/Models/Receipt';
import { ReceiptService } from 'src/app/Service/receipt.service';

@Component({
  selector: 'app-view-receipt',
  templateUrl: './view-receipt.component.html',
  styleUrls: ['./view-receipt.component.css']
})
export class ViewReceiptComponent implements OnInit {
  allReceipt : Receipt []  = [];
  userId = parseInt(localStorage.getItem('userId')!);
  
  constructor(private  receiptService : ReceiptService) {}

  ngOnInit(): void {
    this.GetAllReceiptUserByID();
  }
  
  GetAllReceiptUserByID(){
    this.receiptService.GetAllReceiptUserByID(this.userId).subscribe({
      next : response  =>{
        console.log(response);
        this.allReceipt=response;
      }, 
      error : err =>{
        console.log(err);
      }
    })
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
