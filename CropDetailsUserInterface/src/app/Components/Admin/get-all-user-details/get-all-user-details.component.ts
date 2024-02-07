import { Component, OnInit } from '@angular/core';
import { AddUserDTO, UserModel } from 'src/app/Models/registerUser';
import { RegisterUserService } from 'src/app/Service/register-user.service';

@Component({
  selector: 'app-get-all-user-details',
  templateUrl: './get-all-user-details.component.html',
  styleUrls: ['./get-all-user-details.component.css']
})
export class GetAllUserDetailsComponent implements OnInit {

  userId:number =0;
ngOnInit(): void {
  this.getAllUsers();
}
userDetails : any;
activateStatus : boolean = true;
constructor(private registerService : RegisterUserService){}

getAllUsers(){
  this.registerService.getAllUsers().subscribe({
    next: response => {
      console.log("res;"+response);
      this.userDetails = response;
    },
    error : err =>{
      console.log(err);
    }
  })
}

toggleActivateStatus(i: number,userDto : AddUserDTO){
  this.userId = i;
  this.registerService.toggleActivateStatus(this.userId,userDto).subscribe({
    next: response =>{
      console.log(response);
      this.getAllUsers();
    }, error : err =>{
      console.log(err);
    }
  })
}


}
