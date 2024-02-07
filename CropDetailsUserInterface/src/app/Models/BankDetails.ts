export interface BankDetails{
    accountId :number,
    accountNumber :string,
    bankName :string,
    ifscCode : string,
    userId : number, 
    // user  : any
}

export interface BankDetailsDTO{
    accountNumber :string,
    bankName :string,
    ifscCode : string,
    userId : number
}