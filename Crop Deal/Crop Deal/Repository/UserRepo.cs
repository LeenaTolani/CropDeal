using Crop_Deal.Interface;
using Crop_Deal.Model;
using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;


namespace Crop_Deal.Repository
{
    public class UserRepo : IUser
    {
        public readonly CropDetailDbContext _context;
        public UserRepo(CropDetailDbContext context)
        {
            _context = context;
        }

        #region Add New User 
        public async Task<bool> AddUser(UserDTO user)
        {
            try
            {
                if (user == null)
                {
                    return false;
                }
                if (await CheckIfUserExists(user) == true )
                {
                    var addNewUser = new User
                    {
                        UserName = user.UserName ,
                        Name = user.Name,
                        Email = user.Email,
                        Password = user.Password,
                        Location = user.Location,
                        Role = user.Role,
                        Phone = user.Phone
                    };
                    await _context.Users.AddAsync(addNewUser);
                    await _context.SaveChangesAsync();
                    await SendMail(user);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return false;
        }
        #endregion

        #region To check if username + phone number + email already exists
        public async Task<bool> CheckIfUserExists(UserDTO user)
        {
            try
            {
                if(await _context.Users.AnyAsync(u => (u.UserName == user.UserName) || u.Email == user.Email || u.Phone == user.Phone)) {
                    return false;
                }
                return true;
            } catch (Exception ex)
            {
                throw;
            }
            return false;

        }
        #endregion


        #region deleting the user id 
        public async Task<bool> DeleteUser(string username)
        {
            try
            {
                var userDetails = await _context.Users.FirstOrDefaultAsync(u => (u.UserName == username));
                if (userDetails !=null){
                    _context.Users.Remove(userDetails);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            } catch (Exception ex)
            {
                throw;
            }
        }
        #endregion


        #region Update Users Details
        public async Task<bool> UpdateUser(int id, UserDTO userDTO)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => (u.UserName == userDTO.UserName));
                    if (user != null )
                    {
                        
                        user.Name = userDTO.Name;
                        user.Email = userDTO.Email;
                        user.Password = userDTO.Password;
                        user.Location = userDTO.Location;
                        user.Phone = userDTO.Phone;
                        
                       // _context.Users.Update(updateDetails);
                        await _context.SaveChangesAsync();
                        return true;
                    }
               
                return false;
            } catch (Exception ex)
            {
                throw; 
            }
        }
        #endregion


        #region Getting User by id 
        public async Task<User> GetUserDetails(int id)
        {
            try
            {
                var userDetails = await  _context.Users.FirstOrDefaultAsync(u => u.UserId== id) ;
                return userDetails;
            } catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Getting All the Users Detail
        public async Task<IEnumerable<User>> GetAllUserDetails()
        {
            try
            {
                return await _context.Users.Where(u=> u.Role != "admin").ToListAsync(); 
            } catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Getting Users Details Of User
        public async Task<User> GetBankDetailsOfUser(int userId)
        {
            try
            {
                var details = await _context.Users.Include("BankDetails").FirstOrDefaultAsync(a => a.UserId == userId);
                return details;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Send Mail After Registration
        public async Task<bool> SendMail(UserDTO user)
        {
            try
            {
                //Sending Email
                MailMessage mailMessage = new MailMessage("leena.tolani11@gmail.com", user.Email);
                mailMessage.Subject = "Registration Sucessfull";
                mailMessage.Body = "Welcome " + user.Name;
                mailMessage.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                NetworkCredential networkCredential = new NetworkCredential("leena.tolani11@gmail.com", "rkfk xedb ttey mgae");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = networkCredential;
                smtp.Send(mailMessage);

                return true;
            } catch(Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Activate and Deactivate User
        public async Task<bool> checkActivationStatus(int userId,UserDTO userDto)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(a=>a.UserId == userId);
                user.ActiveStatus = !user.ActiveStatus;
                _context.SaveChanges();
                return user.ActiveStatus;
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}