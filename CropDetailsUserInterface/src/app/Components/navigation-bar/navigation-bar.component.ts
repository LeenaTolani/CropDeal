import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/Service/authentication.service';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.css']
})
export class NavigationBarComponent {
  searchCrop : string = '';
  constructor(public authService : AuthenticationService, private router : Router){}
  
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
    // this.router.navigate(['User/Home']); 
  }

  viewProfile(){
    this.router.navigate(['User/Profile']);
  }

  // search1(){
  //   console.log("abcd"+ this.searchCrop);
  // }
}
