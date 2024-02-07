using Crop_Deal.Interface;
using Crop_Deal.Model;
using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using MailKit.Security;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Immutable;

namespace Crop_Deal.Repository
{
    public class ReceiptRepo : IReceipt
    {
        private readonly CropDetailDbContext _context;
        public ReceiptRepo(CropDetailDbContext context)
        {
            _context = context;
        }

        #region Adding Receipts
        public async Task<String> AddReceipt(ReceiptDTO receiptDto)
        {
            try
            {

                if(receiptDto == null )
                {
                    return "receiptDto is null";
                }

                //Checking if the farmer,dealer and, crop exists
                var validateDetails = await ValidateUser(receiptDto.FarmerId, receiptDto.DealerId, receiptDto.CropId);
                if (validateDetails != "Valid")
                {
                    return validateDetails;
                }


                //Checking if the quantity is available or not
                var finAvailableQuantity =await CheckQuantity(receiptDto.QuantityRequired, receiptDto.CropId);
                if (finAvailableQuantity != "Available") {
                    return finAvailableQuantity;
                }

                var newReceipt = new Receipt
                {
                    FarmerId = receiptDto.FarmerId,
                    DealerId = receiptDto.DealerId,
                    QuantityRequired = receiptDto.QuantityRequired,
                    DealDate =  DateTime.Now,
                    CropId = receiptDto.CropId
                };
                var cropDetails = await _context.CropDetails.FindAsync(newReceipt.CropId);
                var price = cropDetails.PricePerKg;
                
                newReceipt.TotalAmount = newReceipt.QuantityRequired * price;

                await _context.AddAsync(newReceipt);
                await _context.SaveChangesAsync();

                SendEmailFarmer(newReceipt);
                SendEmailDealer(newReceipt);
                return "Receipt Added Successfully";

            }
            catch (Exception ex)
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
                return await _context.Receipt.ToListAsync();
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
                return await _context.Receipt
                    .Include(c => c.CropDetails)
                    .Include(f => f.FarmerUser)
                    .Include(d => d.DealerUser)
                    .ToListAsync();
            }
            catch (Exception ex)
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
                var getReceipt = await _context.Receipt.FirstOrDefaultAsync(a=> a.ReciptId ==  id);

                return getReceipt;
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
                var joinTables = await _context.Receipt.Include(f=> f.FarmerUser).Include(d => d.DealerUser).Include(c=> c.CropDetails).Where(a => a.FarmerId == userId || a.DealerId == userId).ToListAsync();
               // var getReceipt = await joinTables;
                 // var result = await _context.Receipt.Include(cd => cd.FarmerId == getReceipt.FarmerId).Where(i => i.)
                return joinTables;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion


        #region Validating farmer,dealer and, crop exists
        public async Task<string> ValidateUser(int farmerId, int dealerId, int cropId)
        {
            var checkCrop = await _context.CropDetails.FirstOrDefaultAsync(a => a.CropId == cropId);
            if(checkCrop == null )
            {
                return "CropId is Invalid";
            }
            var checkFarmer = await _context.Users.FirstOrDefaultAsync(a=> a.UserId == farmerId);
            var checkDealer = await _context.Users.FirstOrDefaultAsync(a => a.UserId == dealerId);
            if(checkFarmer == null && checkDealer == null)
            {
                return "Farmer Id or Dealear Id is Invalid";
            }
            return "Valid";
        }
        #endregion

        #region Validating if the quantity is available or not
        public async Task<string> CheckQuantity(int quantity, int cropId)
        {
            var cropDetails = await _context.CropDetails.FirstOrDefaultAsync(a=> a.CropId == cropId);
            var cropQuantity = cropDetails.QuantityInKg;  
            if(quantity <= cropQuantity && quantity >0)
            {
                // updating the quantity
                cropDetails.QuantityInKg -= quantity;
                
                return "Available";
            }
            return "Quantity required by the dealer is not available";
        }
        #endregion

        #region Send Mail To farmer
        public async Task<bool> SendEmailFarmer(Receipt receipt)
        {
            try
            {

                var farmerDetails = (await _context.Users.FirstOrDefaultAsync(a => a.UserId == receipt.FarmerId));
                var dealerDetails = await _context.Users.FirstOrDefaultAsync(a => a.UserId == receipt.DealerId);
                var cropDetails = await _context.CropDetails.FirstOrDefaultAsync(a => a.CropId == receipt.CropId);

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("leena.tolani11@gmail.com"));
                email.To.Add(MailboxAddress.Parse(farmerDetails.Email));
                email.Subject = "Your crops are sold";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = "Dear " + farmerDetails.Name + ",<br>" +
                    "<p> Congratulations ! your crop has been sold successfully, Login Now to Download your Invoice</p>" +
                    "<strong>CROP DETAILS : " +
                    "Crop name:" + cropDetails.CropName + "<br> " +
                    "Crop type :" + cropDetails.CropType + "<br>" +
                    "Crop Quantity:" + receipt.QuantityRequired + "<br>" +
                    "Dealer Name:" + dealerDetails.Name + "<br> " +
                    "Dealer Contact:" + dealerDetails.Phone +"<br> " +
                    "Dealer Location:" + dealerDetails.Location +"<br> " +
                    " ----------------------------------------------------------------------------------------------------------<br>" +
                    "Total : Rs." + receipt.TotalAmount + "<br>" + "Order Date:" + receipt.DealDate + "<br>" +
                     " ----------------------------------------------------------------------------------------------------------<br>" +
                    "<br>Thank you for choosing Crop Deal!<br> " +
                    "<pre>                                                                                  regards,</pre>" +
                    "<pre>                  "

                };
                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("leena.tolani11@gmail.com", "rkfk xedb ttey mgae");
                smtp.Send(email);
                smtp.Disconnect(true);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
            return false;
        }
        #endregion


        #region Send Mail To farmer
        public async Task<bool> SendEmailDealer( Receipt receipt )
        {
            try
            {

                var farmerDetails = (await _context.Users.FirstOrDefaultAsync(a => a.UserId == receipt.FarmerId));
                var dealerDetails = await _context.Users.FirstOrDefaultAsync(a => a.UserId == receipt.DealerId);
                var cropDetails = await _context.CropDetails.FirstOrDefaultAsync(a => a.CropId == receipt.CropId);

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("leena.tolani11@gmail.com"));
                email.To.Add(MailboxAddress.Parse(dealerDetails.Email));
                email.Subject = "Crop Purchase Confirmation";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = "Dear " + dealerDetails.Name + ",<br>" +
                    "<p> Congratulations! You have successfully purchased a crop.Login now to view and download your invoice.</p>" +
                    "<strong>CROP DETAILS : "+
                    "Crop Name:" + cropDetails.CropName + "<br> " +
                    "Crop Type :" + cropDetails.CropType + "<br>" +
                    "CROP QUANTITY :" + receipt.QuantityRequired +  "<br>" +
                    " ----------------------------------------------------------------------------------------------------------<br>" +
                    "ORDER TOTAL : Rs." + receipt.TotalAmount + "<br>" +"ORDER DATE      :" + receipt.DealDate + "<br>" +
                     " ----------------------------------------------------------------------------------------------------------<br>" +
                    "<br>Thank you for choosing Crop Deal!<br> " +
                    "<pre>                                                                                  regards,</pre>" +
                    "<pre>                  " 
                };
                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("leena.tolani11@gmail.com", "rkfk xedb ttey mgae");
                smtp.Send(email);
                smtp.Disconnect(true);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
            return false;
        }
        #endregion
    }
}
