import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthenticationService } from './authentication.service';
import { Observable } from 'rxjs';
import { crops, cropsDTO } from '../Models/crops';

@Injectable({
  providedIn: 'root'
})
export class CropDetailsService {

  baseurl = 'https://localhost:44397/';
  constructor(private http: HttpClient, private authService : AuthenticationService) { }

  addCrop(cropsDto : cropsDTO){
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization"  : `Bearer ${token}`
    });
    return this.http.post(this.baseurl + 'api/CropDetails/AddCropDetails',cropsDto,{headers});
  }

  getAllPostedCropByFarmerId(userId: number):Observable<crops[]>{
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization"  : `Bearer ${token}`
    });
    return this.http.get<crops[]>(this.baseurl + 'api/CropDetails/User/'+  userId ,{headers});
  }

  getCropById(id:string): Observable<crops>{
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization"  : `Bearer ${token}`
    });
    return this.http.get<crops>(this.baseurl+ "api/CropDetails/CropDetails/"+id, {headers});
  }

   updateCrop(id:number , cropDto: cropsDTO){
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization"  : `Bearer ${token}`
    });
    return this.http.put(this.baseurl + "api/CropDetails/UpdateCropDetails/" + id, cropDto, {headers});
  }

  getCropDetailswithCropID(cropId :number):Observable<crops>{
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization"  : `Bearer ${token}`
    });
    return  this.http.get<crops>(this.baseurl + "api/CropDetails/croptype/"+ cropId,{headers});
  }

  getAllCrop():Observable<crops[]>{
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization"  : `Bearer ${token}`
    });
    return this.http.get<crops[]>(this.baseurl + 'api/CropDetails/User/CropType', {headers});
  }

  searchCrop(cropName: string):Observable<crops[]>{
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization" : `Bearer ${token}`
    });
    return this.http.get<crops[]>(this.baseurl+'api/CropDetails/SearchNyName/'+cropName,{headers});
  }

  

  
}
