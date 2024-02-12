export interface cropsDTO{
    cropName : string,
    quantityInKg : number,
    pricePerKg : number,
    location : string,
    cropTypeId : number,
    userId : number
}

export interface crops{
    cropId : number, 
    cropName : string,
    quantityInKg : number,
    pricePerKg :number,
    location : string,
    receipt : any,
    cropTypeId : number,
    cropType :any,
    userId :number,
    user :any,
    cropImageUrl :any
}

export interface postCropsDTO{
    cropName : string,
    quantityInKg : number,
    pricePerKg : number,
    location : string,
    cropTypeId : number,
    userId : number,
    cropImage :any
}


export interface postCropsDTO{
    cropName : string,
    quantityInKg : number,
    pricePerKg : number,
    location : string,
    cropTypeId : number,
    userId : number,
    cropImage :any
}