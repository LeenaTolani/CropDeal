import { Component } from '@angular/core';
import { AuthenticationService } from 'src/app/Service/authentication.service';

@Component({
  selector: 'app-dashboard-page',
  templateUrl: './dashboard-page.component.html',
  styleUrls: ['./dashboard-page.component.css']
})
export class DashboardPageComponent {
  constructor(private authService : AuthenticationService){}

  logout(){
    this.authService.logoutUser();
  }

  isRole():string{
    return (localStorage.getItem('role')!);
  }
}
