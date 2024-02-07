export interface Receipt{
    reciptId : number,
    farmerId : number,
    farmerUser :any,
    dealerId: number,
    dealerUser : any,
    totalAmount  : number,
    quantityRequired : number ,
    dealDate : any,
    cropId : number,
    cropDetails : any
}


export interface ReceiptDto{
    farmerId : number,
    dealerId: number,
    quantityRequired : number ,
    cropId : number,
}
