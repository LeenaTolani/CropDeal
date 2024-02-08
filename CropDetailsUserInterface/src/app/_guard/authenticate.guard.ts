// auth.guard.ts
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router, UrlTree } from '@angular/router';
import { AuthenticationService } from '../Service/authentication.service';
import { ToastrService } from 'ngx-toastr';
 
@Injectable({
  providedIn: 'root',
})
export class authenticateGuard implements CanActivate {

  constructor(private authService: AuthenticationService, private router: Router, private toastr : ToastrService) {}
 

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree {
      const user:any = this.authService.isRole();
      const allowedRoles = next.data['roles'] && next.data['roles'][0];
      if(allowedRoles === user ){
        return true;
      } 
      else if( allowedRoles === "common" ){
        return true;
      }
      return this.router.parseUrl('/User/Home');
  }

}