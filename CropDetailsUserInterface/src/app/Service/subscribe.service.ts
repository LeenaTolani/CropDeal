import { Token } from '@angular/compiler';
import { subscribe, subscribeDTO } from './../Models/Subscribe';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthenticationService } from './authentication.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SubscribeService {

  baseurl = 'https://localhost:44397/';
  constructor(private http:HttpClient, private authService : AuthenticationService) { }

  addSubscription(subscribe : subscribeDTO){
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization" : `Bearer ${token}` 
    });
    return this.http.post(this.baseurl+"api/Subscribe/AddSubscribe", subscribe,{headers});
  }

  deleteSubscription(subscribeId : number){
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization" : `Bearer ${token}`
    }) ;
    return this.http.delete(this.baseurl +"api/Subscribe/DeleteSubscribe/"+ subscribeId , {headers});
  }

  getSubscriptionByUserId(subscribeId : number): Observable<subscribe>{
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization" : `Bearer ${token}`
    }) ;
    return this.http.get<subscribe>(this.baseurl + "api/Subscribe/SubscribedCropByUserId/"+subscribeId,{headers});
  }
}
