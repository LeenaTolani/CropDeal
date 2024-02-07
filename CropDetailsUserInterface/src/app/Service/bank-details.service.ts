import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BankDetails, BankDetailsDTO } from '../Models/BankDetails';
import { AuthenticationService } from './authentication.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BankDetailsService {

  baseurl = 'https://localhost:44397/';
  constructor(private http: HttpClient, private authService : AuthenticationService) { }

  addBankDetails(bankDto : BankDetailsDTO){
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization"  : `Bearer ${token}`
    });
    return this.http.post(this.baseurl + 'api/BankDetails/AddBankDetails',bankDto,{headers});
  }

  editBankDetails(id:string,bankDto : BankDetailsDTO){
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization"  : `Bearer ${token}`
    });
    return this.http.put(this.baseurl + 'api/BankDetails/UpdateBankDetails/'+  id ,bankDto,{headers});
  }

  getBankDetailsById(id:string): Observable<BankDetails>{
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization"  : `Bearer ${token}`
    });
    return this.http.get<BankDetails>(this.baseurl+ "api/BankDetails/BankDetails/"+id, {headers});
  }

  
  getBankDetailsByUserId(id:string): Observable<BankDetails>{
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization"  : `Bearer ${token}`
    });
    return this.http.get<BankDetails>(this.baseurl+ "api/BankDetails/BankDetailsByUserID/"+id, {headers});
  }

}
