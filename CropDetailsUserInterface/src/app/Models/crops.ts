export interface cropsDTO{
    cropName : string,
    quantityInKg : number,
    pricePerKg : number,
    location : string,
    cropTypeId : number,
    userId : number,
    // cropPicture :any
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
    // cropPicture :any
}
