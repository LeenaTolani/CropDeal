import { subscribe, subscribeDTO } from './../../Models/Subscribe';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/Service/authentication.service';
import { SubscribeService } from 'src/app/Service/subscribe.service';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.css']
})
export class NavigationBarComponent implements OnInit{
  searchCrop : string = '';
  userId! : number;
  subscribe : any = null;

  subscribeDto : subscribeDTO ={
    subscriber : true,
    userId : 0
  };
  constructor(public authService : AuthenticationService, private router : Router
    ,private subscribeService : SubscribeService){}

  ngOnInit(): void {
    this.getSubscribeByUserId();
  }
  
  login(){
    this.router.navigate(['/User/Login']); 
  }
  
  register(){
    this.router.navigate(['User/Register']); 
  }

  logout(){
    this.authService.logoutUser();
  }

  homeLoggedIn(){
    this.router.navigate(['User/Dashboard']); 
  }

  home(){
    this.router.navigate(['User/Home']);
  }

  viewProfile(){
    this.router.navigate(['User/Profile']);
  }

  getSubscribeByUserId(){
    this.userId = parseInt(localStorage.getItem('userId')!);
    this.subscribeService.getSubscriptionByUserId(this.userId).subscribe({
      next: res =>{
        this.subscribe = res;
      },
      error : err =>{
        console.error("Error : ",err)
      }
    })
  }

  addSubscribe(){
    this.subscribeDto.userId=parseInt(localStorage.getItem('userId')!);
    this.subscribeService.addSubscription(this.subscribeDto).subscribe({
      next:response=>{
        console.log("success");
        this.getSubscribeByUserId();
      },
      error:error=>{
        console.log(error);
      }
    })
   }
   
   UnSubscribe(){
    if(this.subscribe){
      this.subscribeService.deleteSubscription(this.subscribe.subscribeId).subscribe({
        next:response=>{
          console.log("Deleted");
          this.getSubscribeByUserId();
        },
        error:error=>{
          console.log(error);
        }
      })
    }
   
   }

}
