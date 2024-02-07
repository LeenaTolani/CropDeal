import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthenticationService } from './authentication.service';
import { Receipt, ReceiptDto } from '../Models/Receipt';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReceiptService {

  baseurl = 'https://localhost:44397/';
  constructor(private http: HttpClient, private authService : AuthenticationService) { }

  addReceipt(receiptDto : ReceiptDto){
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization"  : `Bearer ${token}`
    });
    return this.http.post(this.baseurl + "api/Receipt/AddReceipt", receiptDto ,{headers});
  }

  GetAllReceiptUserByID(userId : number):Observable<Receipt[]>{
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization"  : `Bearer ${token}`
    });
    return this.http.get<Receipt[]>(this.baseurl + "api/Receipt/GetReceiptUserByID/"+ userId ,{headers});
  }

  GetAllReceiptsWithCropAndUser():Observable<Receipt[]>{
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization"  : `Bearer ${token}`
    });
    return this.http.get<Receipt[]>(this.baseurl + 'api/Receipt/GetAllReceiptWithCropAndUser', {headers});
  }
  
}
