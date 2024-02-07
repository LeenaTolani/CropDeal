import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { LoginUser } from 'src/app/Models/registerUser';
import { LoginService } from 'src/app/Service/login.service';
import {JwtHelperService} from '@auth0/angular-jwt'; 
import { AuthenticationService } from 'src/app/Service/authentication.service';
import { Router } from '@angular/router';
import { BankDetailsService } from 'src/app/Service/bank-details.service';

@Component({
  selector: 'app-login-user',
  templateUrl: './login-user.component.html',
  styleUrls: ['./login-user.component.css']
})

export class LoginUserComponent {
  userLogin : LoginUser = {
    user  : '',
    password: ''
  }
  id ='';
  path : string ='';
  loginResponseData : any;

  loginForm = new FormGroup({
    user : new  FormControl('',[Validators.required]),
    password :  new  FormControl('',[Validators.required]),
  })

  constructor(private loginService : LoginService, private toastr : ToastrService, 
    private authService :AuthenticationService,private router : Router,
    private bankDetailsService : BankDetailsService ){}
  
  login(){
    if(this.loginForm.valid){
      this.loginService.loginUser(this.userLogin).subscribe({
        next: response =>{
          if (response && response.hasOwnProperty('value')) { 
            this.loginResponseData = response;                      
            this.authService.setToken(this.loginResponseData.value);
            const token = this.authService.getToken();
            if(token == "Invalid User Details"){
              this.toastr.error('Please Enter Correct User Details.'); 
            }
            const decodedToken = this.authService.decodeJwtToken();
            console.log(decodedToken);
            //
            //this.checkBankDetails();
            // this.router.navigate([this.path]);
             this.router.navigate(['User/Dashboard']);
            this.toastr.success('User login successfully.');        
          }else{
            this.toastr.error('Please Enter Correct User Details.');       
            console.log("error");
          }
          }
         ,
        error: error =>{console.log(error);
          this.toastr.error('Failed to login user. Please try again.');
          },
        complete:()=>console.log("request completed")

      })
    }
    else{
      this.loginForm.markAllAsTouched();
    }
   }

   checkBankDetails(){
    this.id =localStorage.getItem("userId")!;
    this.bankDetailsService.getBankDetailsByUserId(this.id).subscribe({
      next : res => {
        console.log(res);
        console.log("next");
        if(res!== null){
          this.path  = 'User/Dashboard';
        } 
        this.path = 'User/BankDetails';
      },
      error : err =>{
        console.log("error "+err);
      },
      complete:() =>{
        console.log("Bank Details");
      }
    });
   }
}