import { NotExpr } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CropType } from 'src/app/Models/cropType';
import { CropTypeService } from 'src/app/Service/crop-type.service';

@Component({
  selector: 'app-list-crop-type',
  templateUrl: './list-crop-type.component.html',
  styleUrls: ['./list-crop-type.component.css']
})
export class ListCropTypeComponent implements OnInit {
  cropTypes : CropType[] = [];
  
  ngOnInit(): void {
    this.getAllCropType();
  }

  constructor(private cropTypeService : CropTypeService,private toastr : ToastrService){}
  getAllCropType() {
    this.cropTypeService.getAllCroptype().subscribe({
      next : response =>{
        this.cropTypes = response;
        console.log(this.cropTypes);
      },
      error : error => {
        console.log(error);
      },
      complete: () => console.log("Get All Crop Type Request has been Completed") 
    }
    )}

    deleteCropType(id : number){
      if(confirm("Are you sure you want to delete this data?")){
        this.cropTypeService.deleteCropType(id).subscribe({
          next: response =>{
            this.getAllCropType();
            this.toastr.success("CropType Deleted Successfully!");
          }, 
          error: error =>{
            console.log(error);
            this.toastr.error("CropType is not Deleted!");
          }
        }
        )}
      }
    }

