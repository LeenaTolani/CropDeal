import { Token } from '@angular/compiler';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AddUserDTO, UserModel } from '../Models/registerUser';
import { Observable } from 'rxjs';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class RegisterUserService {
  baseurl = 'https://localhost:44397/';
  constructor(private  http:HttpClient,private authService:AuthenticationService) { }
  
  addNewUser(addUserDto : AddUserDTO){
    return this.http.post(this.baseurl + 'api/User/Adduser' , addUserDto); 
  }

  getUserProfile(userId:number): Observable<UserModel>{
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization"  : `Bearer ${token}`
    });
    return this.http.get<UserModel>(this.baseurl + 'api/User/' + userId, {headers}); 
  }

  editUserProfile( id : number,addUserDTO:AddUserDTO){
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization"  : `Bearer ${token}`
    });
    return this.http.put(this.baseurl + 'api/User/Updateuser/'+id,addUserDTO ,{headers}); 
  }

  getAllUsers():Observable<UserModel[]>{
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization"  : `Bearer ${token}`,
    });
    return this.http.get<UserModel[]>(this.baseurl + 'api/User/Getalluser' , {headers}); 
  }

  toggleActivateStatus(userId : number, userDto : AddUserDTO){
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      'Authorization' : `Bearer ${token}`
    }) ;
    return this.http.put(this.baseurl+'api/User/ActivateStatus/'+userId,userDto,{headers});
  }
}
