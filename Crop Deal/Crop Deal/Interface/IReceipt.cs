using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;

namespace Crop_Deal.Interface
{
    public interface IReceipt
    {
        Task<Receipt> GetReceiptByID(int id);
        Task<IEnumerable<Receipt>> GetAllReceipts();
        Task<String> AddReceipt(ReceiptDTO receiptDto);
        Task<string> CheckQuantity(int quantity, int cropId);
        Task<string> ValidateUser(int farmerId, int dealerId, int cropId);
        Task<IEnumerable<Receipt>> GetReceiptUserByID(int userId);
        Task<IEnumerable<Receipt>> GetAllReceiptsWithCropAndUser();
            }
}
