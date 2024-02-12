import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { postCropsDTO } from 'src/app/Models/crops';
import { AuthenticationService } from 'src/app/Service/authentication.service';
import { CropDetailsService } from 'src/app/Service/crop-details.service';
import { CropTypeService } from 'src/app/Service/crop-type.service';

@Component({
  selector: 'app-add-crop',
  templateUrl: './add-crop.component.html',
  styleUrls: ['./add-crop.component.css']
})
export class AddCropComponent implements  OnInit {
addcrops : postCropsDTO= {
  cropName : '',
  quantityInKg : 0,
  pricePerKg : 0,
  location : '',
  cropTypeId: 0,
  userId : 0,
  cropImage : ''
};
img : any;
cropTypes : any;
cropForm = new FormGroup({
  cropName: new FormControl('',[Validators.required]),
  quantity: new FormControl('',[Validators.required, Validators.min(1)]),
  price:new FormControl('',[Validators.required, Validators.min(1)]),
  location:new FormControl('',[Validators.required]),
  type:new FormControl('',[Validators.required]),
  image : new FormControl('',[Validators.required])
});
constructor(private cropsService : CropDetailsService , private cropTypeService : CropTypeService ,private toastr : ToastrService,
  private route : Router){}
  
ngOnInit(): void {
  this.getAllCropType() ;
}

onSelectFile(e:any){
  if(e.target.files){
    this.img=<File>e.target.files[0];
    console.log(this.img);
  }
}

submit(){
  if(this.cropForm.valid){
    // this.addcrops.userId = parseInt(localStorage.getItem('userId')!);
    const form = new FormData();
    form.append("cropName", this.addcrops.cropName); 
    form.append("quantityInKg", this.addcrops.quantityInKg.toString());
    form.append("pricePerKg", this.addcrops.pricePerKg.toString());
    form.append("location", this.addcrops.location);
    form.append("cropTypeId", this.addcrops.cropTypeId.toString());
    form.append("userId", localStorage.getItem('userId')!);
    form.append("cropImage", this.img,this.img.name);
    
    this.cropsService.addCrop(form).subscribe({
      next : response =>{console.log(response);
      this.toastr.success("Crop Added Successfully!");
      this.route.navigate(['/Farmer/GetAllCrops']);
    },
      error : err =>
      { 
        console.error(err);
        this.toastr.error("Crop Details are Not Added!");
      }
      
    });
  }else{
    this.cropForm.markAllAsTouched();
  }
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
