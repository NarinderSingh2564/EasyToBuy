using System.ComponentModel;
using System.Reflection;
using EasyToBuy.Data;
using EasyToBuy.Data.DBClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
using EasyToBuy.Models.UIModels;
using Microsoft.EntityFrameworkCore;

namespace EasyToBuy.Services.Interactions
{
    public class AccountService : IDisposable
    {
        #region Private Variables

        private ApplicationDbContext _dbContext;

        private Component component = new Component();
        private bool disposed = false;
        private IntPtr handle;

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    component.Dispose();
                CloseHandle(handle);
                handle = IntPtr.Zero;
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        #endregion

        #region Constructor

        public AccountService()
        {
            _dbContext = new ApplicationDbContext();
        }

        #endregion

        #region Destructor

        ~AccountService()
        {
            Dispose(false);
        }

        #endregion
        public async Task<ApiResponseModel> CheckUser(string mobile, string password)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var dbUser = await _dbContext.tblUser.Where(x => x.Mobile == mobile).FirstOrDefaultAsync();

                if (dbUser == null)
                {
                    apiResponseModel.Status = false;
                    apiResponseModel.Message = "User not found.";
                }
                else if (dbUser.Password != password)
                {
                    apiResponseModel.Status = false;
                    apiResponseModel.Message = "Incorrect password.";
                }
                else if (!dbUser.IsActive)
                {
                    apiResponseModel.Status = false;
                    apiResponseModel.Message = "User is not active.";
                }
                else
                {
                    var userDetails = new UserModel
                    {
                        Id = dbUser.Id,
                        FullName = dbUser.FullName,
                        Mobile = dbUser.Mobile,
                        Email = dbUser.Email,
                    };

                    apiResponseModel.Status = true;
                    apiResponseModel.Message = "User logged in successfully.";
                    apiResponseModel.Response = userDetails;
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }

            return apiResponseModel;
        }
        public async Task<ApiResponseModel> UserRegistration(UserInputModel userInputModel)

        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var isUserExists = await _dbContext.tblUser.Where(x => x.Mobile == userInputModel.Mobile).FirstOrDefaultAsync();

                if (isUserExists != null)
                {
                    apiResponseModel.Status = false;
                    apiResponseModel.Message = "This mobile number is already registered.";
                }

                else
                {
                    var dbUser = new User();

                    dbUser.FullName = userInputModel.FullName;
                    dbUser.Email = userInputModel.Email;
                    dbUser.Mobile = userInputModel.Mobile;
                    dbUser.Password = userInputModel.Password;
                    dbUser.CreatedBy = userInputModel.CreatedBy;
                    dbUser.CreatedOn = DateTime.Now;
                    dbUser.IsActive = true;

                    await _dbContext.tblUser.AddAsync(dbUser);
                    await _dbContext.SaveChangesAsync();

                    apiResponseModel.Status = true;
                    apiResponseModel.Message = "User registered successfully.";
                }

            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }

            return apiResponseModel;
        }
        public async Task<IEnumerable<AddressModel>> GetAddressListByUserId(int userID)
        {
            var addressList = new List<AddressModel>();

            try
            {
                var query = (from a in _dbContext.tblAddress
                             join at in _dbContext.tblAddressType
                             on a.AddressTypeId equals at.Id
                             where a.UserId == userID

                             select new AddressModel
                             {
                                 Id = a.Id,
                                 City = a.City,
                                 State = a.State,
                                 Country = a.Country,
                                 FullAddress = a.FullAddress,
                                 AddressTypeId = a.AddressTypeId,
                                 TypeOfAddress = at.TypeOfAddress,
                                 Pincode = a.Pincode,
                                 IsDeliveryAddress = a.IsDeliveryAddress,
                             }).ToListAsync();

                addressList = await query.ConfigureAwait(false);

            }

            catch (Exception ex)
            {
                var message = ex.Message;
            }

            return addressList;
        }
        public async Task<IEnumerable<AddressTypeModel>> GetAddressTypeList()
        {
            var addressTypeList = new List<AddressTypeModel>();
            try
            {
                var dbAddressTypeList = await _dbContext.tblAddressType.Where(x => x.IsActive == true).ToListAsync();
                foreach (var type in dbAddressTypeList)
                {
                    addressTypeList.Add(new AddressTypeModel
                    {
                        Id = type.Id,
                        TypeOfAddress = type.TypeOfAddress,
                        IsActive = type.IsActive,
                    });
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return addressTypeList;
        }
        public async Task<ApiResponseModel> AddressAddEdit(AddressInputModel addressInputModel)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var dbAddress = await _dbContext.tblAddress.Where(x => x.Id == addressInputModel.Id).FirstOrDefaultAsync();

                if (dbAddress != null)
                {
                    dbAddress.FullAddress = addressInputModel.FullAddress;
                    dbAddress.Pincode = addressInputModel.Pincode;
                    dbAddress.City = addressInputModel.City;
                    dbAddress.Country = addressInputModel.Country;
                    dbAddress.State = addressInputModel.State;
                    dbAddress.AddressTypeId = addressInputModel.AddressTypeId;
                    dbAddress.IsDeliveryAddress = false;
                    dbAddress.UpdatedBy = addressInputModel.UpdatedBy;
                    dbAddress.UpdatedOn = DateTime.Now;
                }
                else
                {
                    var addressObj = new Address();

                    addressObj.UserId = addressInputModel.UserId;
                    addressObj.FullAddress = addressInputModel.FullAddress;
                    addressObj.Pincode = addressInputModel.Pincode;
                    addressObj.CreatedBy = addressInputModel.CreatedBy;
                    addressObj.CreatedOn = DateTime.Now;
                    addressObj.IsActive = true;
                    addressObj.City = addressInputModel.City;
                    addressObj.State = addressInputModel.State;
                    addressObj.Country = addressInputModel.Country;
                    addressObj.AddressTypeId = addressInputModel.AddressTypeId;
                    addressObj.IsDeliveryAddress = false;

                    await _dbContext.AddAsync(addressObj);
                }

                await _dbContext.SaveChangesAsync();

                apiResponseModel.Status = true;
                apiResponseModel.Message = addressInputModel.Id > 0 ? "Address updated successfully." : "Address added successfully.";

            }

            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return apiResponseModel;
        }
        public async Task<ApiResponseModel> SetDeliveryAddress(int id, int userId)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var dbAdressByUserId = await _dbContext.tblAddress.Where(x => x.UserId == userId).ToListAsync();

                if (dbAdressByUserId.Count > 0)
                {
                    foreach (var item in dbAdressByUserId)
                    {
                        item.IsDeliveryAddress = false;
                    }
                }

                var deliveryAddress = await _dbContext.tblAddress.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (deliveryAddress != null)
                {
                    deliveryAddress.IsDeliveryAddress = true;
                    apiResponseModel.Status = true;
                    apiResponseModel.Message = "Delivery address updated successfully";
                }
                await _dbContext.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return apiResponseModel;
        }

    }
}
