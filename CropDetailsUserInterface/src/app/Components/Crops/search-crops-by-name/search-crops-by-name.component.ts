import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ReceiptDto } from 'src/app/Models/Receipt';
import { crops } from 'src/app/Models/crops';
import { CropDetailsService } from 'src/app/Service/crop-details.service';
import { ReceiptService } from 'src/app/Service/receipt.service';

@Component({
  selector: 'app-search-crops-by-name',
  templateUrl: './search-crops-by-name.component.html',
  styleUrls: ['./search-crops-by-name.component.css']
})
export class SearchCropsByNameComponent implements OnInit {
  
  imageUrl = this.cropService.baseurl;
  allcrops : crops [] = [];
  inputnumber : { [key: number]: number } = {};
  reviewCrop:any;
  quantity = 0;
  totalPrice = 0;
  addNewReceipt : ReceiptDto ={
    farmerId : 0,
    dealerId: 0,
    quantityRequired : 0 ,
    cropId : 0,
  };
  constructor(private  cropService:CropDetailsService,private toastr : ToastrService
    ,private receiptService : ReceiptService,private router : Router, private route : ActivatedRoute){}
  ngOnInit(): void {
    this.getAllCrops();
  }
  

  submit(){
    console.log("ok");
    if(this.quantity>0){
      console.log(this.reviewCrop);
      this.addNewReceipt.farmerId = this.reviewCrop.userId;
      this.addNewReceipt.dealerId = parseInt(localStorage.getItem('userId')!),
      this.addNewReceipt.quantityRequired = this.quantity;
      this.addNewReceipt.cropId = this.reviewCrop.cropId;
      this.addReceipt(this.addNewReceipt);
      console.log(this.addNewReceipt);
      this.getAllCrops();
     // this.router.navigate(['User/ViewCrops']);
      this.toastr.success("Thank You For Buying the Crop");
      this.getAllCrops();
      document.getElementById("modal-close")?.click();
      // this.getAllCrops();
      // window.location.reload();
    } else{
      this.toastr.warning("Quantity cannot be Zero");
    }
  }

  getAllCrops(){
    this.route.paramMap.subscribe({
      next:(params)=>{
        const search= params.get('search')!;
        if(search){ 
          
          this.cropService.searchCrop(search).subscribe({
            next : response =>{
              console.log(response);
              this.allcrops = response;
              this.initializeInputNumbers();
              console.log(this.allcrops);
            }, 
            error : err =>{console.log(err);},
            complete: () => console.log("Get All Crop Type Request has been Completed")
          })
        } else{
          this.cropService.getAllCrop().subscribe({
            next : response =>{
              console.log(response);
              this.allcrops = response;
              this.initializeInputNumbers();
              console.log(this.allcrops);
            }, 
            error : err =>{console.log(err);},
            complete: () => console.log("Get All Crop Type Request has been Completed")
          })
        }

  }
}
    )
}

  getCropDetailswithCropID(cropId :number,index :number){
      this.quantity =  this.inputnumber[index];
      this.totalPrice = this.quantity * this.allcrops[index].pricePerKg ;
    this.cropService.getCropDetailswithCropID(cropId).subscribe({
      next : response =>{
        console.log(response);
        this.reviewCrop = response;
      },
      error : err => {console.log(err);}
    })
  }

  addReceipt(receiptDto :ReceiptDto){
    this.receiptService.addReceipt(receiptDto).subscribe({
      next : response =>{
        console.log(response);
      },
      error : err =>{console.log(err)}
    })
  }

  initializeInputNumbers() {
    this.allcrops.forEach((_, index) => {
        this.inputnumber[index] = 0;
    });
  }

  plus(index:number)
  {
    if(this.inputnumber[index] <= (this.allcrops[index].quantityInKg)-1){
      console.log("input", this.inputnumber[index]);
      console.log("quan", this.allcrops[index].quantityInKg);
      this.inputnumber[index]++;
    } else{
      this.toastr.error("Maximum Quantity Reached!");
    }
  }

  minus(index:number)
  {
    if (this.inputnumber[index] !== 0) {
      this.inputnumber[index]--;
      this.quantity =  this.inputnumber[index];
      this.totalPrice = this.quantity * this.allcrops[index].pricePerKg ;
    } else{
      this.toastr.error("Quantity Cannot be Zero!");
    }
  }

  isRole():string{
    return  localStorage.getItem('role')!;
  }

  
}