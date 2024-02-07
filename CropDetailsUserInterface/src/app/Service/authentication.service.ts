import { Token } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
  import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private router : Router) { }


getToken(){
  return localStorage.getItem('token');   
}

setToken(token:string){
  localStorage.setItem('token',token);              
}

decodeJwtToken(){
  const token = this.getToken();
  const jwtHelper = new JwtHelperService();
  const decodedToken = jwtHelper.decodeToken(token!);
  localStorage.setItem('userId',decodedToken.nameid);
  localStorage.setItem('role',decodedToken.role);
  localStorage.setItem('username',decodedToken.unique_name);
  return decodedToken;
}

isLoggedIn(){
  return !!localStorage.getItem('token');
}

logoutUser(){
  localStorage.removeItem('token');
  localStorage.removeItem('userId');
  localStorage.removeItem('role');
  localStorage.removeItem('username'); 
  this.router.navigate(['User/Login']);
}

isRole():string{
  return localStorage.getItem('role')!;
}


}