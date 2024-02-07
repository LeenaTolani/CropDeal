using Crop_Deal.Interface;
using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace Crop_Deal.Services
{
    public class ReceiptServices
    {
        private readonly IReceipt _iReceipt;
        public ReceiptServices(IReceipt iReceipt)
        {
            _iReceipt = iReceipt;
        }


        #region Adding Receipts
        public async Task<String> AddReceipt(ReceiptDTO receiptDto)
        {
            try
            {
                return await _iReceipt.AddReceipt(receiptDto);
            } catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Get All the Receipts
        public async Task<IEnumerable<Receipt>> GetAllReceipts()
        {
            try
            {
                return await _iReceipt.GetAllReceipts();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Get All the Receipts with all details
        public async Task<IEnumerable<Receipt>> GetAllReceiptsWithCropAndUser()
        {
            try
            {
                return await _iReceipt.GetAllReceiptsWithCropAndUser();
            } catch(Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Get Receipt By Id
        public async Task<Receipt> GetReceiptByID(int id)
        {

            try
            {
                return await _iReceipt.GetReceiptByID(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion


        #region Get Receipt By User Id
        public async Task<IEnumerable<Receipt>> GetReceiptUserByID(int userId)
        {
            try
            {
                return await _iReceipt.GetReceiptUserByID(userId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

    }
}
