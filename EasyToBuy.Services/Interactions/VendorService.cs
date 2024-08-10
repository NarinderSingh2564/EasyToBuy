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
using Microsoft.EntityFrameworkCore.Storage;

namespace EasyToBuy.Services.Interactions
{
    public class VendorService : IDisposable
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

        public VendorService()
        {
            _dbContext = new ApplicationDbContext();
        }

        #endregion

        #region Destructor

        ~VendorService()
        {
            Dispose(false);
        }

        #endregion

        public async Task<ApiResponseModel> VendorAddEdit(VendorInputModel vendorInputModel)
        {
            var apiResponseModel = new ApiResponseModel();
          
            using (DbContextTransaction transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var checkVendorDuplicacy = await _dbContext.tblVendor.Where(x => x.Mobile == vendorInputModel.vendorBasicDetailsInputModel.Mobile && x.Email == vendorInputModel.vendorBasicDetailsInputModel.Email && x.Id != vendorInputModel.vendorBasicDetailsInputModel.Id).FirstOrDefaultAsync();

                    if (checkVendorDuplicacy != null)
                    {
                        apiResponseModel.Status = false;
                        apiResponseModel.Message = "This mobile number and email is already registered, please try with new.";
                    }

                    else
                    {
                        var dbVendor = await _dbContext.tblVendor.Where(x => x.Id == vendorInputModel.vendorBasicDetailsInputModel.Id).FirstOrDefaultAsync();

                        if (dbVendor != null)
                        {
                            dbVendor.Name = vendorInputModel.vendorBasicDetailsInputModel.Name;
                            dbVendor.Email = vendorInputModel.vendorBasicDetailsInputModel.Email;
                            dbVendor.Password = vendorInputModel.vendorBasicDetailsInputModel.Password;
                            dbVendor.Mobile = vendorInputModel.vendorBasicDetailsInputModel.Mobile;
                            dbVendor.Type = vendorInputModel.vendorBasicDetailsInputModel.Type;
                            dbVendor.IdentificationType = vendorInputModel.vendorBasicDetailsInputModel.IdentificationType;
                            dbVendor.IdentificationNumber = vendorInputModel.vendorBasicDetailsInputModel.IdentificationNumber;
                            dbVendor.Pincode = vendorInputModel.vendorBasicDetailsInputModel.Pincode;
                            dbVendor.City = vendorInputModel.vendorBasicDetailsInputModel.City;
                            dbVendor.State = vendorInputModel.vendorBasicDetailsInputModel.State;
                            dbVendor.Country = vendorInputModel.vendorBasicDetailsInputModel.Country;
                            dbVendor.FullAddress = vendorInputModel.vendorBasicDetailsInputModel.FullAddress;
                            dbVendor.UpdatedBy = vendorInputModel.vendorBasicDetailsInputModel.UpdatedBy;
                            dbVendor.UpdatedOn = DateTime.Now;
                        }
                        else
                        {
                            var vendorObj = new Vendor();

                            vendorObj.Name = vendorInputModel.vendorBasicDetailsInputModel.Name;
                            vendorObj.VendorCode = "ETB-" + new Random().Next(50000).ToString();
                            vendorObj.Email = vendorInputModel.vendorBasicDetailsInputModel.Email;
                            vendorObj.Password = vendorInputModel.vendorBasicDetailsInputModel.Password;
                            vendorObj.Mobile = vendorInputModel.vendorBasicDetailsInputModel.Mobile;
                            vendorObj.Type = vendorInputModel.vendorBasicDetailsInputModel.Type;
                            vendorObj.IdentificationType = vendorInputModel.vendorBasicDetailsInputModel.IdentificationType;
                            vendorObj.IdentificationNumber = vendorInputModel.vendorBasicDetailsInputModel.IdentificationNumber;
                            vendorObj.Pincode = vendorInputModel.vendorBasicDetailsInputModel.Pincode;
                            vendorObj.City = vendorInputModel.vendorBasicDetailsInputModel.City;
                            vendorObj.State = vendorInputModel.vendorBasicDetailsInputModel.State;
                            vendorObj.Country = vendorInputModel.vendorBasicDetailsInputModel.Country;
                            vendorObj.FullAddress = vendorInputModel.vendorBasicDetailsInputModel.FullAddress;
                            vendorObj.Status = "Pending";
                            vendorObj.StatusRemarks = "Your request has been sent to admin.";
                            vendorObj.CreatedBy = 1;
                            vendorObj.CreatedOn = DateTime.Now;

                            await _dbContext.tblVendor.AddAsync(vendorObj);
                            await _dbContext.SaveChangesAsync();

                            //var vendorCompanyDetailsObj = new VendorCompanyDetails();

                            //vendorCompanyDetailsObj.VendorId = vendorObj.Id;
                            //vendorCompanyDetailsObj.CompanyName = vendorInputModel.vendorCompanyDetailsInputModel.CompanyName;
                            //vendorCompanyDetailsObj.Description = vendorInputModel.vendorCompanyDetailsInputModel.Description;
                            //vendorCompanyDetailsObj.DealingPerson = vendorInputModel.vendorCompanyDetailsInputModel.DealingPerson;
                            //vendorCompanyDetailsObj.GSTIN = vendorInputModel.vendorCompanyDetailsInputModel.GSTIN;
                            //vendorCompanyDetailsObj.Pincode = vendorInputModel.vendorCompanyDetailsInputModel.Pincode;
                            //vendorCompanyDetailsObj.City = vendorInputModel.vendorCompanyDetailsInputModel.City;
                            //vendorCompanyDetailsObj.State = vendorInputModel.vendorCompanyDetailsInputModel.State;
                            //vendorCompanyDetailsObj.Country = vendorInputModel.vendorCompanyDetailsInputModel.Country;
                            //vendorCompanyDetailsObj.FullAddress = vendorInputModel.vendorCompanyDetailsInputModel.FullAddress;
                        }

                        apiResponseModel.Status = true;
                        apiResponseModel.Message = vendorInputModel.vendorBasicDetailsInputModel.Id > 0 ? "Vendor updated successfully." : "Vendor's basic details added successfully.";
                    }
                }

                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            }

            return apiResponseModel;
        }
        public async Task<IEnumerable<VendorModel>> GetVendorList()
        {
            var vendorList = new List<VendorModel>();

            try
            {
                var dbVendorList = await _dbContext.tblVendor.ToListAsync();
                foreach (var vendor in dbVendorList)
                {
                    vendorList.Add(new VendorModel
                    {
                        Id = vendor.Id,
                        Name = vendor.Name,
                        Email = vendor.Email,
                        Mobile = vendor.Mobile,
                        Pincode = vendor.Pincode,
                        City = vendor.City,
                        State = vendor.State,
                        Country = vendor.Country,
                        FullAddress = vendor.FullAddress,
                        Status = vendor.Status,
                        StatusRemarks = vendor.StatusRemarks,
                        IsLicensed = vendor.IsLicensed,
                        LicenseExpiredOn = vendor.LicenseExpiredOn,
                    });
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return vendorList;
        }
        public async Task<ApiResponseModel> VendorStatusUpdate(int vendorId, int userId, string status, string statusRemarks)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var dbVendor = await _dbContext.tblVendor.Where(x => x.Id == vendorId).FirstOrDefaultAsync();

                if (dbVendor != null)
                {
                    dbVendor.Status = status;
                    dbVendor.StatusRemarks = statusRemarks;
                    dbVendor.UpdatedBy = userId;
                    dbVendor.UpdatedOn = DateTime.Now;
                    await _dbContext.SaveChangesAsync();

                    apiResponseModel.Status = true;
                    apiResponseModel.Message = "Your request has been " + status;
                }

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return apiResponseModel;
        }

        public async Task<ApiResponseModel> VendorLogin(string mobile, string password)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var dbVendor = await _dbContext.tblVendor.Where(x => x.Mobile == mobile).FirstOrDefaultAsync();

                if (dbVendor != null)
                {
                    if (dbVendor.Password != password)
                    {
                        apiResponseModel.Status = false;
                        apiResponseModel.Message = "Incorrect password";
                    }
                    else if (dbVendor.Status == "Approved")
                    {
                        apiResponseModel.Status = true;
                        apiResponseModel.Message = "User logged in successfully";
                        apiResponseModel.Response = dbVendor;

                        dbVendor.LastLoginDate = DateTime.Now;
                        await _dbContext.SaveChangesAsync();
                    }
                    else if (dbVendor.Status == "Rejected")
                    {
                        apiResponseModel.Status = false;
                        apiResponseModel.Message = "Sorry, you are rejected by admin.";
                    }
                    else if (dbVendor.Status == "Pending")
                    {
                        apiResponseModel.Status = false;
                        apiResponseModel.Message = "Your request is pending.";
                    }
                    else
                    {
                        apiResponseModel.Status = false;
                        apiResponseModel.Message = "You are blocked.";
                    }
                }
                else
                {
                    apiResponseModel.Status = false;
                    apiResponseModel.Message = "User not found";
                }
            }

            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return apiResponseModel;
        }

        public async Task<IEnumerable<SPGetVendorOrdersCountById_Result>> GetVendorOrdersCount(int vendorId)
        {
            var VendorOrdersCount = new List<SPGetVendorOrdersCountById_Result>();

            try
            {
                var sqlQuery = "exec SPGetVendorOrdersCountById @VendorId";

                SqlParameter parameter1 = new SqlParameter("@VendorId", (int)vendorId);


                VendorOrdersCount = await _dbContext.vendorOrdersCountById_Results.FromSqlRaw(sqlQuery, parameter1).ToListAsync();

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return VendorOrdersCount;
        }
    }
}
