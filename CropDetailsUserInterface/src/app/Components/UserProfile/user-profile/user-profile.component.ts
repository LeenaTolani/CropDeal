import { Component, OnInit } from '@angular/core';
import { UserModel } from 'src/app/Models/registerUser';
import { RegisterUserService } from 'src/app/Service/register-user.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  ngOnInit(): void {
    this.getUserById();
  }
  userDetails : UserModel = {
    userName : '',
    name : '',
    email : '',
    location : '',
    role : '',
    phone : '',
    password : '',
    bankDetails : null
    // activeStatus : true
  };

  userIdDetails:any;

  constructor(private userDetailsService : RegisterUserService){}

  getUserById(){
    this.userIdDetails =  localStorage.getItem('userId');
    this.userDetailsService.getUserProfile(this.userIdDetails).subscribe({
      next:(response)=>{
        console.log(response); 
        this.userDetails.userName = response.userName;
        this.userDetails.name = response.name;
        this.userDetails.email = response.email;
        this.userDetails.location = response.location;
        this.userDetails.phone = response.phone;
        this.userDetails.role = response.role;
        this.userDetails.password = response.password;
        console.log(this.userDetails);
      },
      error:(error)=> {
        console.log(error);      }
    })    
  };

  role():string{
    return localStorage.getItem('role')!;
  }
  }




