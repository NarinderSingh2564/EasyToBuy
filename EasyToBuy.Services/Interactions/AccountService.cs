using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using EasyToBuy.Data;
using EasyToBuy.Data.DBClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.CommonModels;
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
        public async Task<ApiResponseModel> CheckUser(string mobile, string password, string role)
        {
            var apiResponseModel = new ApiResponseModel();

            dynamic? dbUser = null;

            try
            {
                if (role == "User")
                {
                    dbUser = await _dbContext.tblUser.Where(x => x.Mobile == mobile || x.Email == mobile).FirstOrDefaultAsync();
                }
                if (role == "Customer")
                {
                    dbUser = await _dbContext.tblCustomer.Where(x => x.Mobile == mobile || x.Email == mobile).FirstOrDefaultAsync();
                }

                if (dbUser != null)
                {
                    if (dbUser.Password != password)
                    {
                        apiResponseModel.Status = false;
                        apiResponseModel.Message = "Incorrect password.";
                    }
                    else if (role == "Vendor" && dbUser.Status != "Approved")
                    {
                        apiResponseModel.Status = false;
                        apiResponseModel.Message = "User is not active.";
                    }
                    else if (role == "Customer" && !dbUser.IsActive)
                    {
                        apiResponseModel.Status = false;
                        apiResponseModel.Message = "User is not active.";
                    }
                    else
                    {
                        var userDetails = new UserDetailsModel()
                        {
                            Id = dbUser.Id,
                            Name = dbUser.Name,
                            Email = dbUser.Email,
                            Mobile = dbUser.Mobile,
                            Role = role,
                        };
                        if (role == "Vendor")
                        {
                            dbUser.LastLoginDate = DateTime.Now;
                            await _dbContext.SaveChangesAsync();
                        }
                        apiResponseModel.Status = true;
                        apiResponseModel.Message = "User logged in successfully.";
                        apiResponseModel.Response = userDetails;

                    }
                }
                else
                {
                    apiResponseModel.Status = false;
                    apiResponseModel.Message = "User not found.";
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }

            return apiResponseModel;
        }
        public async Task<ApiResponseModel> CustomerRegistration(CustomerInputModel customerInputModel)

        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var isCustomerExists = await _dbContext.tblCustomer.Where(x => x.Mobile == customerInputModel.Mobile).FirstOrDefaultAsync();

                if (isCustomerExists != null)
                {
                    apiResponseModel.Status = false;
                    apiResponseModel.Message = "This mobile number is already registered.";
                }

                else
                {
                    var dbCustomer = new Customer();

                    dbCustomer.Name = customerInputModel.Name;
                    dbCustomer.Email = customerInputModel.Email;
                    dbCustomer.Mobile = customerInputModel.Mobile;
                    dbCustomer.Password = customerInputModel.Password;
                    dbCustomer.CreatedBy = customerInputModel.CreatedBy;
                    dbCustomer.CreatedOn = DateTime.Now;
                    dbCustomer.IsActive = true;

                    await _dbContext.tblCustomer.AddAsync(dbCustomer);
                    await _dbContext.SaveChangesAsync();

                    apiResponseModel.Status = true;
                    apiResponseModel.Message = "Customer registered successfully.";
                }

            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }

            return apiResponseModel;
        }
        public async Task<IEnumerable<AddressModel>> GetAddressListByCustomerId(int customerId)
        {
            var addressList = new List<AddressModel>();

            try
            {
                var query = (from a in _dbContext.tblAddress
                             join at in _dbContext.tblAddressType
                             on a.AddressTypeId equals at.Id
                             where a.CustomerId == customerId

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

                    addressObj.CustomerId = addressInputModel.CustomerId;
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
        public async Task<ApiResponseModel> SetDeliveryAddress(int addressId, int CustomerId)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var dbAdressByUserId = await _dbContext.tblAddress.Where(x => x.CustomerId == CustomerId).ToListAsync();

                if (dbAdressByUserId.Count > 0)
                {
                    foreach (var item in dbAdressByUserId)
                    {
                        item.IsDeliveryAddress = false;
                    }
                }

                var deliveryAddress = await _dbContext.tblAddress.Where(x => x.Id == addressId).FirstOrDefaultAsync();
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
        public async Task<CustomerModel> GetCustomerAccountProfile(int CustomerId)
        {
            var userModel = new CustomerModel();

            try
            {
                var userDetail = _dbContext.tblCustomer.Where(x => x.Id == CustomerId).FirstOrDefault();
                if (userDetail != null)
                {
                    userModel.Id = userDetail.Id;
                    userModel.Name = userDetail.Name;
                    userModel.Mobile = userDetail.Mobile;
                    userModel.Email = userDetail.Email;
                    userModel.Password = userDetail.Password;
                    userModel.IsActive = userDetail.IsActive;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return userModel;
        }
        public async Task<AddressModel> GetAddressUserByUserId(int userId)
        {
            var addressModel = new AddressModel();

            try
            {
                var userAddressDetail = _dbContext.tblAddress.Where(x => x.CustomerId == userId && x.IsDeliveryAddress == true).ToList().FirstOrDefault();
                if (userAddressDetail != null)
                {
                    addressModel.Id = userAddressDetail.CustomerId;
                    addressModel.City = userAddressDetail.City;
                    addressModel.State = userAddressDetail.State;
                    addressModel.Country = userAddressDetail.Country;
                    addressModel.FullAddress = userAddressDetail.FullAddress;
                    addressModel.Pincode = userAddressDetail.Pincode;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return addressModel;
        }
    }
}
