import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AddUserDTO, UserModel } from 'src/app/Models/registerUser';
import { RegisterUserService } from 'src/app/Service/register-user.service';

@Component({
  selector: 'app-edit-user-profile',
  templateUrl: './edit-user-profile.component.html',
  styleUrls: ['./edit-user-profile.component.css']
})
export class EditUserProfileComponent implements OnInit {
  ngOnInit(): void {
    this.getUserById();
  }
  userDetails : AddUserDTO = {
    userName : '',
    name : '',
    email : '',
    location : '',
    role : '',
    phone : '',
    password: ''
  };

  userIdDetails = Number(localStorage.getItem('userId'));

  constructor(private userDetailsService : RegisterUserService,private route: Router, private toastr : ToastrService){}

  editUserDetailsForm = new FormGroup({
    userName: new FormControl('',[Validators.required]),
    name :  new  FormControl('',[Validators.required]),
    email :  new  FormControl('', [Validators.required, Validators.email]),
    password :  new  FormControl('', [Validators.required, Validators.minLength(7)]),
    location :  new  FormControl('',[Validators.required]),
    role :  new  FormControl('',[Validators.required]),
    phone :  new  FormControl('', [Validators.required, Validators.minLength(10)])
  })

  editUserById(){
    console.log(this.userIdDetails);
    this.userDetailsService.editUserProfile(this.userIdDetails,this.userDetails).subscribe({
      next:(response)=>{
        console.log(response); 
        console.log(this.userDetails);
        this.toastr.success("Your Details are Updated Successfully!")
        this.route.navigate(['User/Profile']);
      },
      error:(error)=> {
        console.log(error);      
      }
    })
  };

  getUserById(){
    this.userDetailsService.getUserProfile(this.userIdDetails).subscribe(
      {next :response =>{console.log(response);
      this.userDetails.userName = response.userName; 
      this.userDetails.name = response.name;
      this.userDetails.email = response.email;
      this.userDetails.location = response.location;
      this.userDetails.phone = response.phone;
      this.userDetails.password = response.password;
      this.userDetails.role = response.role;
      },
      
    error : err=> console.log(err)
  }
    )
  }
}   





