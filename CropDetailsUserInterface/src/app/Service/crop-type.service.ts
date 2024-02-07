import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CropType, CropTypeDTO } from '../Models/cropType';
import { Observable } from 'rxjs';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class CropTypeService {

  baseurl = 'https://localhost:44397/';
  constructor(private http: HttpClient, private authService : AuthenticationService) { }

    addCropType(addCropTypeDto : CropTypeDTO){
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization"  : `Bearer ${token}`
    });
    return this.http.post(this.baseurl + 'api/CropType/AddCropTypeDetails',addCropTypeDto,{headers});
  }

  getAllCroptype():Observable<CropType[]>{
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization"  : `Bearer ${token}`
    });
    return this.http.get<CropType[]>(this.baseurl + 'api/CropType/GetAllCropTypeDetails', {headers});
  }
  deleteCropType(id : number){
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization"  : `Bearer ${token}`
    });
    return this.http.delete(this.baseurl + 'api/CropType/DeleteCropType/'+ id, {headers});
  }

  getCropTypeById(id:string): Observable<CropType>{
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization"  : `Bearer ${token}`
    });
    return this.http.get<CropType>(this.baseurl+ "api/CropType/CropTypeDetails/"+id, {headers});
  }

  updateCropType(id:number , cropTypeDto: CropTypeDTO){
    let token = this.authService.getToken();
    let headers = new HttpHeaders({
      "Authorization"  : `Bearer ${token}`
    });
    return this.http.put(this.baseurl + "api/CropType/UpdateCropDetails/" + id, cropTypeDto, {headers});
  }
}
