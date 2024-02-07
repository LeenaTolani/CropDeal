import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { cropsDTO } from 'src/app/Models/crops';
import { CropDetailsService } from 'src/app/Service/crop-details.service';
import { CropTypeService } from 'src/app/Service/crop-type.service';

@Component({
  selector: 'app-edit-crops',
  templateUrl: './edit-crops.component.html',
  styleUrls: ['./edit-crops.component.css']
})
export class EditCropsComponent implements OnInit {

  editCrops : cropsDTO= {
    cropName : '',
    quantityInKg : 1,
    pricePerKg : 1,
    location : '',
    cropTypeId: 0,
    userId : 0
  };
  
  id : any;
  cropForm = new FormGroup({
    cropName: new FormControl('',[Validators.required]),
    quantity: new FormControl('',[Validators.required, Validators.min(1)]),
    price:new FormControl('',[Validators.required, Validators.min(1)]),
    location:new FormControl('',[Validators.required]),
    type:new FormControl('',[Validators.required])
  });

  constructor(private cropsService : CropDetailsService , private cropTypeService : CropTypeService ,
    private route : ActivatedRoute, private routerToNav : Router,
    private toastr : ToastrService){}
  ngOnInit(): void {
    this.getAllCropType();
    this.getCropById();
  }

  
  cropTypes : any;
  submit(){
    if(this.cropForm.valid){
      console.log( "id: "+ this.id);
      this.cropsService.updateCrop(this.id,this.editCrops).subscribe({
        next: response =>{
          console.log(response);
          this.toastr.success("Crop Edited Successfully");
          this.routerToNav.navigate(['/Farmer/GetAllCrops']); 

        }, 
        error : err =>{
          console.log(err);
        },
        complete: () =>  console.log("Request Completed")
      })
    } else{
      this.cropForm.markAllAsTouched();
    }
  }

  getCropById(){
    this.route.paramMap.subscribe({
      next:(params)=>{
        const id= params.get('id')!;
        if(id){
          this.cropsService.getCropById(id).subscribe({
            next: response =>{
              console.log(response);
              console.log(this.cropTypes);
              this.id = id;
              this.editCrops.cropName = response.cropName;
              this.editCrops.location = response.location;
              this.editCrops.pricePerKg = response.pricePerKg;
              this.editCrops.quantityInKg = response.quantityInKg;
              this.editCrops.cropTypeId = response.cropTypeId;
              this.editCrops.userId = parseInt(localStorage.getItem('userId')!);
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
  
  }
  

