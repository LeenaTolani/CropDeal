export interface AddUserDTO{
    userName : string;
    name : string;
    email : string;
    password :string;
    location : string;
    role : string;
    phone : string;
}

export interface LoginUser{
    user  : string;
    password: string;
}

export interface UserModel{
    // userId : number;
    userName : string;
    name : string;
    email : string;
    password :string;
    location : string;
    role : string;
    phone : string;
    // activeStatus: boolean
    bankDetails: any;
    // CropDetails: any;
    // Subscribes:any;
    // FarmerName: any;
    // DealerName: any;
}