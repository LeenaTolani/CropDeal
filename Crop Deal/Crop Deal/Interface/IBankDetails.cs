using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;

namespace Crop_Deal.Interface
{
    public interface IBankDetails
    {
        Task<bool> AddBankDetails(BankDetailsDTO bank); 
        Task<bool> UpdateBankDetails(int accountid,BankDetailsDTO bank);
        Task<BankDetails> GetBankDetails(int accountid);
        Task<IEnumerable<BankDetails>> GetAllBankDetails();
        Task<bool> DeleteBankDetails(int accountid);
        Task<BankDetails> GetBankDetailsByUserId(int userid);
    }
}
