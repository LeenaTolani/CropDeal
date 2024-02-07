import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BankDetailsDTO } from 'src/app/Models/BankDetails';
import { BankDetailsService } from 'src/app/Service/bank-details.service';

@Component({
  selector: 'app-add-bank-details',
  templateUrl: './add-bank-details.component.html',
  styleUrls: ['./add-bank-details.component.css']
})
export class AddBankDetailsComponent {

  bankDetailsDto : BankDetailsDTO = {
    accountNumber : '',
    bankName : '',
    ifscCode: '',
    userId: 0
  }

  bankDetailsForm = new FormGroup({
    accountNumber: new FormControl('',[Validators.required]),
    bankName : new FormControl('',[Validators.required, Validators.pattern('^[A-Za-z\s]+$')]),
    ifscCode : new FormControl('',[Validators.required])
  });

    constructor(private bankDetailsService: BankDetailsService, private  router: Router,
    private toastr:ToastrService) { }


    submit(){
       if(this.bankDetailsForm.valid){
        this.bankDetailsDto.userId = parseInt(localStorage.getItem('userId')!);
        this.bankDetailsService.addBankDetails(this.bankDetailsDto).subscribe({
          next:response =>{
            console.log(response);
            this.toastr.success("Bank Details added Successfully");
            this.router.navigate(['/User/ViewBankDetails']); 
          },
          error:error=>{ 
            console.log("Error",error)
            this.toastr.error("Bank Details is not  Added!");
        },
          complete: () =>  console.log("Request Completed")
        })
      } else{
        this.bankDetailsForm.markAllAsTouched();
      }
    }
  }
