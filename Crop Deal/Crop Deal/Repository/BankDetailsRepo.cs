using Crop_Deal.Interface;
using Crop_Deal.Model;
using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Crop_Deal.Repository
{
    public class BankDetailsRepo : IBankDetails
    {
        public readonly CropDetailDbContext _context;
        public BankDetailsRepo(CropDetailDbContext context)
        {
            _context = context;
        }


        #region Add Bank Detail 
        public async Task<bool> AddBankDetails(BankDetailsDTO bank)
        {
            try
            {
                if (bank== null)
                {
                    return false;
                }
                
                    var addBankDetails = new BankDetails
                    {
                        AccountNumber = bank.AccountNumber,
                        BankName = bank.BankName,
                        IfscCode = bank.IfscCode,
                        UserId = bank.UserId
                    };
                    await _context.BankDetails.AddAsync(addBankDetails);
                    await _context.SaveChangesAsync();
                    return true;
                
            }
            catch (Exception ex)
            {
                throw;
            }
            return false;
        }
        #endregion


        #region Update Bank Detail 
        public async Task<bool> UpdateBankDetails(int accountid,BankDetailsDTO bank)
        {
            try
            {
                if (bank== null)
                {
                    return false;
                }

                var bankDetails = await _context.BankDetails.FirstOrDefaultAsync(u => u.AccountId == accountid);
                if(bankDetails != null)
                {
                    bankDetails.AccountId = accountid;
                    bankDetails.BankName = bank.BankName;
                    bankDetails.IfscCode = bank.IfscCode;
                    bankDetails.UserId = bank.UserId;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion


        #region Getting the bank details
        public async Task<BankDetails> GetBankDetails(int accountid)
        {
            try
            {
                var bankDetails = await _context.BankDetails.FirstOrDefaultAsync(u => u.AccountId == accountid);
                return bankDetails;
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
                var bankDetails = await _context.BankDetails.FirstOrDefaultAsync(u => u.UserId == userid);
                return bankDetails;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Getting all the bank details 
        public async  Task<IEnumerable<BankDetails>> GetAllBankDetails()
        {
            try
            {
                return await  _context.BankDetails.ToListAsync();
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
                var bankDetails = await _context.BankDetails.FirstOrDefaultAsync(u => (u.AccountId == accountid));
                if (bankDetails != null)
                {
                    _context.BankDetails.Remove(bankDetails);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        #endregion


    }
}
