import { Component, OnInit } from '@angular/core';
import { CropDetailsService } from 'src/app/Service/crop-details.service';

@Component({
  selector: 'app-get-all-posted-crops',
  templateUrl: './get-all-posted-crops.component.html',
  styleUrls: ['./get-all-posted-crops.component.css']
})
export class GetAllPostedCropsComponent  implements  OnInit{
  cropsPosted : any;
  constructor(private cropDetailsService: CropDetailsService) {}
  ngOnInit(): void {
    this.getAllPostedCrops();
  }

  userId : number = parseInt(localStorage.getItem('userId')!);
  getAllPostedCrops(){
    this.cropDetailsService.getAllPostedCropByFarmerId(this.userId).subscribe({
      next : response =>{
        this.cropsPosted = response;
        console.log(this.cropsPosted);
      },
      error : error => {
        console.log(error);
      },
      complete: () => console.log("Get All Crop Type Request has been Completed") 
    }
    )
  }
}
