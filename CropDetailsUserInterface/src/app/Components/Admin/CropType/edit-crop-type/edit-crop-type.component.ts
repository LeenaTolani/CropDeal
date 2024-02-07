import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CropTypeDTO } from 'src/app/Models/cropType';
import { CropTypeService } from 'src/app/Service/crop-type.service';

@Component({
  selector: 'app-edit-crop-type',
  templateUrl: './edit-crop-type.component.html',
  styleUrls: ['./edit-crop-type.component.css']
})
export class EditCropTypeComponent implements  OnInit {
  cropType : CropTypeDTO = {
    cropTypeName : ''
  }

  id : any;


  //Form for validation
  cropTypeForm = new FormGroup({
    cropTypeName: new FormControl('',[Validators.required])
  })

  constructor(private cropTypeService: CropTypeService,private route : ActivatedRoute,
    private toastr : ToastrService,private routeToNav: Router){}
  ngOnInit(): void {
    this.getCropTypeById();
  }

  //submit method
  submit(){
    if(this.cropTypeForm.valid){
      this.cropTypeService.updateCropType(this.id ,this.cropType).subscribe({
        next:response =>{
          console.log(response);
          this.toastr.success("Crop Edited Successfully!");
          this.routeToNav.navigate(['Admin/AllCropType']);
        },
        error:error=>{
          console.log("Error",error)
          this.toastr.success("Crop is not Updated!"); 
        },
        complete: () =>  console.log("Request Completed")
      })
    } else{
      this.cropTypeForm.markAllAsTouched();
    }
  }

  getCropTypeById(){
    this.route.paramMap.subscribe({
      next:(params)=>{
        const id= params.get('id')!;
        if(id){
          this.cropTypeService.getCropTypeById(id).subscribe({
            next: response =>{
              this.id = id
              this.cropType.cropTypeName = response.cropTypeName;
            },
            error :  error => {
              console.log("Error",error);
            }
          }
          )
        }
    }
  })
  }
}