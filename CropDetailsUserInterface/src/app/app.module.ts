import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ListCropTypeComponent } from './Components/Admin/CropType/list-crop-type/list-crop-type.component';
import { AddNewUserComponent } from './Components/Register/add-new-user/add-new-user.component';
import { CommonModule } from '@angular/common';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginUserComponent } from './Components/Login/login-user/login-user.component';
import { DashboardPageComponent } from './Components/dashboard-page/dashboard-page.component';
import { HomeComponent } from './Components/home/home.component';
import { EditCropTypeComponent } from './Components/Admin/CropType/edit-crop-type/edit-crop-type.component';
import { UserProfileComponent } from './Components/UserProfile/user-profile/user-profile.component';
import { EditUserProfileComponent } from './Components/UserProfile/edit-user-profile/edit-user-profile.component';
import { AddCropComponent } from './Components/Farmer/Crops/add-crop/add-crop.component';
import { GetAllPostedCropsComponent } from './Components/Farmer/Crops/get-all-posted-crops/get-all-posted-crops.component';
import { NavigationBarComponent } from './Components/navigation-bar/navigation-bar.component';
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

@NgModule({
  declarations: [
    AppComponent,
    ListCropTypeComponent,
    AddNewUserComponent,
    LoginUserComponent,
    DashboardPageComponent,
    HomeComponent,
    EditCropTypeComponent,
    UserProfileComponent,
    EditUserProfileComponent,
    AddCropComponent,
    GetAllPostedCropsComponent,
    NavigationBarComponent,
    EditCropsComponent,
    AddBankDetailsComponent,
    EditBankDetailsComponent,
    GetBankDetailsComponent,
    ViewAllCropsComponent,
    ViewReceiptComponent,
    GetAllInvoiceComponent,
    GetAllUserDetailsComponent,
    SearchCropsByNameComponent,
    PostCropTypeComponent,],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
