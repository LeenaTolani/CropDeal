import { Component, OnInit } from '@angular/core';
import { BankDetails } from 'src/app/Models/BankDetails';
import { BankDetailsService } from 'src/app/Service/bank-details.service';

@Component({
  selector: 'app-get-bank-details',
  templateUrl: './get-bank-details.component.html',
  styleUrls: ['./get-bank-details.component.css']
})
export class GetBankDetailsComponent implements  OnInit {

  constructor(private bankDetailsService : BankDetailsService){}
  ngOnInit(): void {
    this.getBankDetailsByUserId()
  }
  userId : any;
  bankDetails: BankDetails = {
    accountId : 0,
    accountNumber :"",
    bankName :"",
    ifscCode : "",
    userId : 0
  }
  getBankDetailsByUserId(){
    this.userId = parseInt(localStorage.getItem('userId')!);
    this.bankDetailsService.getBankDetailsByUserId(this.userId).subscribe({
      next:(response)=>{
        console.log(response);
        this.bankDetails= response;
        console.log("Bank Details"+this.bankDetails);
      },
      error: err =>{console.log(err);}
    })
  }
}
