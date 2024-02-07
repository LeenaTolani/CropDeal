
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BankDetailsDTO } from 'src/app/Models/BankDetails';
import { BankDetailsService } from 'src/app/Service/bank-details.service';

@Component({
  selector: 'app-edit-bank-details',
  templateUrl: './edit-bank-details.component.html',
  styleUrls: ['./edit-bank-details.component.css']
})
export class EditBankDetailsComponent implements OnInit {

  bankDetailsDto : BankDetailsDTO = {
    accountNumber : '',
    bankName : '',
    ifscCode: '',
    userId: 0
  }

  bankDetailsForm = new FormGroup({
    accountNumber: new FormControl('',[Validators.required]),
    bankName : new FormControl('',[Validators.required]),
    ifscCode : new FormControl('',[Validators.required])
  });

    constructor(private bankDetailsService: BankDetailsService, private  routerTonav: Router,
    private router : ActivatedRoute,private toastr:ToastrService) { }
    id : any;
    ngOnInit(): void {
      this.getBankDetailsById();
    }


    submit(){
       if(this.bankDetailsForm.valid){
        this.bankDetailsDto.userId = parseInt(localStorage.getItem('userId')!);
        this.bankDetailsService.editBankDetails(this.id,this.bankDetailsDto).subscribe({
          next:response =>{
            console.log(response);

            this.toastr.success("Bank Details added Successfully");
            this.routerTonav.navigate(['/User/ViewBankDetails']); 
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

    getBankDetailsById(){
      this.router.paramMap.subscribe({
        next:(params)=>{
          const id= params.get('id')!;
          // console.log("efg");
          console.log(id);
          if(id){
            this.bankDetailsService.getBankDetailsById(id).subscribe({
              next: response =>{
                console.log(response);
                this.id = id
                this.bankDetailsDto.bankName = response.bankName;
                this.bankDetailsDto.accountNumber = response.accountNumber;
                this.bankDetailsDto.ifscCode = response.ifscCode;
                this.bankDetailsDto.userId = response.userId;
              },
              error :  error => {
                console.log("Error",error);
              }
            }
            )
          }
      }
    })
    }
  }