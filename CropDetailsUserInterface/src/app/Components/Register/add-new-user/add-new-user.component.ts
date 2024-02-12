import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AddUserDTO } from 'src/app/Models/registerUser';
import { RegisterUserService } from 'src/app/Service/register-user.service';


@Component({
  selector: 'app-add-new-user',
  templateUrl: './add-new-user.component.html',
  styleUrls: ['./add-new-user.component.css']
})
export class AddNewUserComponent {
  addUserDto : AddUserDTO={
    userName : '',
    name : '',
    email : '',
    password : '',
    location : '',
    role : '',
    phone : ''
  }

  //Form Validation
  registrationForm = new FormGroup({
    userName : new  FormControl('',[Validators.required]),
    name :  new  FormControl('',[Validators.required]),
    email :  new  FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.pattern(/(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@$!%*#?&^_-]).{8,}/i)]),
    location :  new  FormControl('',[Validators.required]),
    role :  new  FormControl('',[Validators.required]),
    phone :  new  FormControl('', [Validators.required, Validators.minLength(10)])
  })

  constructor(private registrationService : RegisterUserService, private toastr : ToastrService,private router : Router){}
  
  //submit  method
  submit(){
    if(this.registrationForm.valid ) {
      this.registrationService.addNewUser(this.addUserDto).subscribe({
        next:(response)=>{
          console.log(response);
          this.toastr.success("User Added Successfully","Success");
          this.router.navigate(['/User/Login']); 
        },
        error:(error)=> {console.log(error);
          this.toastr.error("User Details  already exists", "Error");
        }, 
        complete : ()=> console.log("Request Completed"),
        
      })
    } else{
      this.registrationForm.markAllAsTouched();
    }
  }

  
}