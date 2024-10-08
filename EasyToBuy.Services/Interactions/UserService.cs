﻿using System.ComponentModel;
using System.Data;
using EasyToBuy.Data;
using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Data.DBClasses;

namespace EasyToBuy.Services.Interactions
{
    public class UserService : IDisposable
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

        public UserService()
        {
            _dbContext = new ApplicationDbContext();
        }

        #endregion

        #region Destructor

        ~UserService()
        {
            Dispose(false);
        }

        #endregion

        public async Task<ApiResponseModel> UserRegistration(UserInputModel userInputModel)
        {
            var apiResponseModel = new ApiResponseModel();

            var transaction = _dbContext.Database.BeginTransaction();
            var errorArea = string.Empty;

            try
            {
                var checkUserDuplicacy = await _dbContext.tblUser.Where(x => x.Mobile == userInputModel.userBasicDetailsInputModel.Mobile && x.Email == userInputModel.userBasicDetailsInputModel.Email && x.Id != userInputModel.userBasicDetailsInputModel.Id).FirstOrDefaultAsync();

                if (checkUserDuplicacy != null)
                {
                    apiResponseModel.Status = false;
                    apiResponseModel.Message = "This mobile number and email is already registered, please try with new.";
                }

                else
                {
                    errorArea = "basic details";

                    var userObj = new User();

                    userObj.Name = userInputModel.userBasicDetailsInputModel.Name;
                    userObj.Email = userInputModel.userBasicDetailsInputModel.Email;
                    userObj.Password = userInputModel.userBasicDetailsInputModel.Password;
                    userObj.Mobile = userInputModel.userBasicDetailsInputModel.Mobile;
                    userObj.RoleId = userInputModel.userBasicDetailsInputModel.RoleId;
                    userObj.IdentificationType = userInputModel.userBasicDetailsInputModel.IdentificationType;
                    userObj.IdentificationNumber = userInputModel.userBasicDetailsInputModel.IdentificationNumber;
                    userObj.Pincode = userInputModel.userBasicDetailsInputModel.Pincode;
                    userObj.City = userInputModel.userBasicDetailsInputModel.City;
                    userObj.State = userInputModel.userBasicDetailsInputModel.State;
                    userObj.Country = userInputModel.userBasicDetailsInputModel.Country;
                    userObj.FullAddress = userInputModel.userBasicDetailsInputModel.FullAddress;
                    userObj.StatusRemarks = "Your request has been sent to admin.";
                    userObj.CreatedBy = 1;
                    userObj.CreatedOn = DateTime.Now;

                    await _dbContext.tblUser.AddAsync(userObj);
                    await _dbContext.SaveChangesAsync();

                    errorArea = "company details";

                    var userCompanyDetailsObj = new UserCompanyDetails();

                    userCompanyDetailsObj.UserId = userObj.Id;
                    userCompanyDetailsObj.CompanyName = userInputModel.userCompanyDetailsInputModel.CompanyName;
                    userCompanyDetailsObj.Description = userInputModel.userCompanyDetailsInputModel.Description;
                    userCompanyDetailsObj.DealingPerson = userInputModel.userCompanyDetailsInputModel.DealingPerson;
                    userCompanyDetailsObj.GSTIN = userInputModel.userCompanyDetailsInputModel.GSTIN;
                    userCompanyDetailsObj.Pincode = userInputModel.userCompanyDetailsInputModel.Pincode;
                    userCompanyDetailsObj.City = userInputModel.userCompanyDetailsInputModel.City;
                    userCompanyDetailsObj.State = userInputModel.userCompanyDetailsInputModel.State;
                    userCompanyDetailsObj.Country = userInputModel.userCompanyDetailsInputModel.Country;
                    userCompanyDetailsObj.FullAddress = userInputModel.userCompanyDetailsInputModel.FullAddress;
                    userCompanyDetailsObj.CreatedBy = 1;
                    userCompanyDetailsObj.CreatedOn = DateTime.Now;
                    userCompanyDetailsObj.IsActive = true;

                    await _dbContext.tblUserCompanyDetails.AddAsync(userCompanyDetailsObj);
                    await _dbContext.SaveChangesAsync();

                    errorArea = "bank details";

                    var userBankDetailsObj = new UserBankDetails();

                    userBankDetailsObj.UserId = userObj.Id;
                    userBankDetailsObj.AccountHolderName = userInputModel.userBankDetailsInputModel.AccountHolderName;
                    userBankDetailsObj.AccountNumber = userInputModel.userBankDetailsInputModel.AccountNumber;
                    userBankDetailsObj.IFSCCode = userInputModel.userBankDetailsInputModel.IFSCCode;
                    userBankDetailsObj.BankName = userInputModel.userBankDetailsInputModel.BankName;
                    userBankDetailsObj.Branch = userInputModel.userBankDetailsInputModel.Branch;
                    userBankDetailsObj.CreatedBy = 1;
                    userBankDetailsObj.CreatedOn = DateTime.Now;
                    userBankDetailsObj.IsActive = true;

                    await _dbContext.tblUserBankDetails.AddAsync(userBankDetailsObj);
                    await _dbContext.SaveChangesAsync();
                }

                transaction.Commit();
                apiResponseModel.Status = true;
                apiResponseModel.Message = "Your registration request has been successfully sent to admin.";
            }

            catch (Exception ex)
            {
                var msg = ex.Message;
                transaction.Rollback();
                apiResponseModel.Status = false;
                apiResponseModel.Message = "Sorry, an error occurred while saving the entries, please check your " + errorArea + ".";
            }

            return apiResponseModel;
        }
        public async Task<IEnumerable<UserModel>> GetUserList()
        {
            var userList = new List<UserModel>();

            try
            {
                var dbUserList = await _dbContext.tblUser.ToListAsync();

                foreach (var user in dbUserList)
                {
                    userList.Add(new UserModel
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        Mobile = user.Mobile,
                        Pincode = user.Pincode,
                        City = user.City,
                        State = user.State,
                        Country = user.Country,
                        FullAddress = user.FullAddress,
                        StatusRemarks = user.StatusRemarks,
                        IsLicensed = user.IsLicensed,
                        LicenseExpiredOn = user.LicenseExpiredOn,
                    });
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return userList;
        }
        public async Task<ApiResponseModel> UserStatusUpdate(int userId, string statusRemarks)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var dbUser = await _dbContext.tblUser.Where(x => x.Id == userId).FirstOrDefaultAsync();

                if (dbUser != null)
                {
                    dbUser.StatusRemarks = statusRemarks;
                    dbUser.IsActive = true;
                    dbUser.UpdatedBy = userId;
                    dbUser.UpdatedOn = DateTime.Now;
                    await _dbContext.SaveChangesAsync();

                    apiResponseModel.Status = true;
                    apiResponseModel.Message = "Your request has been " + statusRemarks;
                }

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return apiResponseModel;
        }
        public async Task<IEnumerable<SPGetUserOrdersCountById_Result>> GetUserOrdersCount(int userId)
        {
            var UserOrdersCount = new List<SPGetUserOrdersCountById_Result>();

            try
            {
                var sqlQuery = "exec spGetUserOrdersCountById @UserId";

                SqlParameter parameter1 = new SqlParameter("@UserId", (int)userId);

                UserOrdersCount = await _dbContext.userOrdersCountById_Results.FromSqlRaw(sqlQuery, parameter1).ToListAsync();

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return UserOrdersCount;
        }
    }
}
