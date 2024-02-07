import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CropTypeDTO } from 'src/app/Models/cropType';
import { CropTypeService } from 'src/app/Service/crop-type.service';

@Component({
  selector: 'app-post-crop-type',
  templateUrl: './post-crop-type.component.html',
  styleUrls: ['./post-crop-type.component.css']
})
export class PostCropTypeComponent {
  cropType : CropTypeDTO = {
    cropTypeName : ''
  }

  //Form for validation
  cropTypeForm = new FormGroup({
    cropTypeName: new FormControl('',[Validators.required])
  })

  constructor(private cropTypeService: CropTypeService, private  router: Router,
    private toastr:ToastrService) { }

  //submit method
  submit(){
    if(this.cropTypeForm.valid){
      this.cropTypeService.addCropType(this.cropType).subscribe({
        next:response =>{
          console.log(response);
          this.toastr.success("Crop Type added Successfully");
          this.router.navigate(['Admin/AllCropType']); 
        },
        error:error=>{ 
          console.log("Error",error)
          this.toastr.success("Crop Type is not  Added!");
      },
        complete: () =>  console.log("Request Completed")
      })
    } else{
      this.cropTypeForm.markAllAsTouched();
    }
  }

  back(){
    this.router.navigate(['Admin/AllCropType']); 
  }
}
