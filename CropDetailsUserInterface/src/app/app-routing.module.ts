import { AuthenticationService } from 'src/app/Service/authentication.service';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
//import { AddCropTypeComponent } from './Components/Admin/CropType/add-crop-type/add-crop-type.component';
import { ListCropTypeComponent } from './Components/Admin/CropType/list-crop-type/list-crop-type.component';
import { AddNewUserComponent } from './Components/Register/add-new-user/add-new-user.component';
import { LoginUserComponent } from './Components/Login/login-user/login-user.component';
import { DashboardPageComponent } from './Components/dashboard-page/dashboard-page.component';
import { authenticateGuard } from './_guard/authenticate.guard';
import { EditCropTypeComponent } from './Components/Admin/CropType/edit-crop-type/edit-crop-type.component';
import { HomeComponent } from './Components/home/home.component';
import { UserProfileComponent } from './Components/UserProfile/user-profile/user-profile.component';
import { EditUserProfileComponent } from './Components/UserProfile/edit-user-profile/edit-user-profile.component';
import { AddCropComponent } from './Components/Farmer/Crops/add-crop/add-crop.component';
import { GetAllPostedCropsComponent } from './Components/Farmer/Crops/get-all-posted-crops/get-all-posted-crops.component';
import { EditCropsComponent } from './Components/Farmer/Crops/edit-crops/edit-crops.component';
import { AddBankDetailsComponent } from './Components/BankDetails/add-bank-details/add-bank-details.component';
import { EditBankDetailsComponent } from './Components/BankDetails/edit-bank-details/edit-bank-details.component';
import { GetBankDetailsComponent } from './Components/BankDetails/get-bank-details/get-bank-details.component';
import { ViewAllCropsComponent } from './Components/Crops/view-all-crops/view-all-crops.component';
import { ViewReceiptComponent } from './Components/Receipt/view-receipt/view-receipt.component';
import { GetAllInvoiceComponent } from './Components/Admin/get-all-invoice/get-all-invoice.component';
import { GetAllUserDetailsComponent } from './Components/Admin/get-all-user-details/get-all-user-details.component';
import { SearchCropsByNameComponent } from './Components/Crops/search-crops-by-name/search-crops-by-name.component';
import { PostCropTypeComponent } from './Components/Admin/CropType/post-crop-type/post-crop-type.component';

 
const routes: Routes = [
  {path:'', component: HomeComponent},
  {path:'User/Home', redirectTo:'/', pathMatch:'full'},
  {path:'User/Register' , component :AddNewUserComponent},
  {path:'User/Login' , component: LoginUserComponent}, 
  // {path:'User/Home', component:HomeComponent},
  {path:'User/SearchCrop/:search',component:SearchCropsByNameComponent},

  {path:'User/Dashboard', component:DashboardPageComponent,canActivate:[authenticateGuard]},
  {path:'User/ViewCrops',component:ViewAllCropsComponent,canActivate:[authenticateGuard]},
  {path:'User/EditMyProfile',component:EditUserProfileComponent,canActivate:[authenticateGuard]},
  {path: 'User/Profile' , component:UserProfileComponent,canActivate:[authenticateGuard]},
  {path:'User/BankDetails',component:AddBankDetailsComponent,canActivate:[authenticateGuard]},
  {path: 'User/EditBankDetails/:id',component:EditBankDetailsComponent,canActivate:[authenticateGuard]},
  {path:'User/ViewBankDetails',component:GetBankDetailsComponent,canActivate:[authenticateGuard]},
  {path:'User/Receipt',component:ViewReceiptComponent,canActivate:[authenticateGuard]},
  {path:'',
    runGuardsAndResolvers: 'always',
    canActivate: [authenticateGuard],
    data: { roles: ['admin'] },
    children: [
      {path:'Admin/AllCropType',component: ListCropTypeComponent},
      {path:'Admin/EditCropType/:id',component:EditCropTypeComponent},
      {path:'Admin/GetInvoice',component:GetAllInvoiceComponent},
      {path:'Admin/AllUsers',component:GetAllUserDetailsComponent},
      {path:'Admin/AddCropType',component:PostCropTypeComponent},
      
    ]
  },
  {path:'',
    runGuardsAndResolvers: 'always',
    canActivate: [authenticateGuard],
    data: { roles: ['farmer'] },
    children: [    
      {path:'Farmer/AddCrop',component:AddCropComponent},
      {path:'Farmer/GetAllCrops',component:GetAllPostedCropsComponent},
      {path:'Farmer/EditCrops/:id',component:EditCropsComponent},
    ]
  },
  {path: '**', component:HomeComponent},

];

@NgModule({
  declarations:[],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
