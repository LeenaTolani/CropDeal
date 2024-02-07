import { BankDetailsService } from './bank-details.service';
import { BankDetails } from './../Models/BankDetails';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginUser } from '../Models/registerUser';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  baseurl = 'https://localhost:44397/';
  constructor(private  http:HttpClient) { }
  
  loginUser(loginuser :LoginUser): Observable<JSON>{
    return this.http.post<JSON>(this.baseurl + 'api/Login' , loginuser); 
  }
}
