using Crop_Deal.Interface;
using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;

namespace Crop_Deal.Services
{
    public class BankDetailsServices
    {
        private readonly IBankDetails _ibankdetails;
        public BankDetailsServices(IBankDetails ibankDetails)
        {
            _ibankdetails = ibankDetails;
        }

        #region Add Bank Detail 
        public async Task<bool> AddBankDetails(BankDetailsDTO bank) 
        {
            try
            {
                return await _ibankdetails.AddBankDetails(bank); 
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Delete the bank details
        public async Task<bool> DeleteBankDetails(int accountid)
        {
            try
            {
                return await _ibankdetails.DeleteBankDetails(accountid);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Getting the bank details
        public async Task<BankDetails>  GetBankDetails(int accountid)
        {
            try
            {
                return await _ibankdetails.GetBankDetails(accountid); 
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Getting the bank details by user id
        public async Task<BankDetails> GetBankDetailsByUserId(int userid)
        {
            try
            {
                return await _ibankdetails.GetBankDetailsByUserId(userid);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion


        #region Update Bank Detail
        public async Task<bool> UpdateBankDetails(int accountid,BankDetailsDTO bank)
        {
            try
            {
                return await _ibankdetails.UpdateBankDetails(accountid,bank); 
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Getting all the bank details
        public async Task<IEnumerable<BankDetails>> GetAllBankDetails()
        {
            try
            {
                return await _ibankdetails.GetAllBankDetails();
            }
            catch (Exception ex)
            {
                throw;
            }
            #endregion
        }
    }
}
