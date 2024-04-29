using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyToBuy.Data;
using EasyToBuy.Data.DBClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
using Microsoft.EntityFrameworkCore;

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

            try
            {
                var checkVendorDuplicacy = await _dbContext.tblVendor.Where(x => x.Mobile == vendorInputModel.Mobile && x.Email == vendorInputModel.Email && x.Id != vendorInputModel.Id).FirstOrDefaultAsync();

                if (checkVendorDuplicacy != null)
                {
                    apiResponseModel.Status = false;
                    apiResponseModel.Message = "This mobile number and email is already registered.";
                }
                else
                {
                    var dbVendor = await _dbContext.tblVendor.Where(x => x.Id == vendorInputModel.Id).FirstOrDefaultAsync();

                    if (dbVendor != null)
                    {
                        dbVendor.Name = vendorInputModel.Name;
                        dbVendor.Email = vendorInputModel.Email;
                        dbVendor.Password = vendorInputModel.Password;
                        dbVendor.Mobile = vendorInputModel.Mobile;
                        dbVendor.Pincode = vendorInputModel.Pincode;
                        dbVendor.City = vendorInputModel.City;
                        dbVendor.State = vendorInputModel.State;
                        dbVendor.Country = vendorInputModel.Country;
                        dbVendor.FullAddress = vendorInputModel.FullAddress;
                        dbVendor.UpdatedBy = vendorInputModel.UpdatedBy;
                        dbVendor.UpdatedOn = DateTime.Now;
                    }
                    else
                    {
                        var vendorObj = new Vendor();

                        vendorObj.Name = vendorInputModel.Name;
                        vendorObj.Email = vendorInputModel.Email;
                        vendorObj.Password = vendorInputModel.Password;
                        vendorObj.Mobile = vendorInputModel.Mobile;
                        vendorObj.DealingPerson = vendorInputModel.DealingPerson;
                        vendorObj.Pincode = vendorInputModel.Pincode;
                        vendorObj.City = vendorInputModel.City;
                        vendorObj.State = vendorInputModel.State;
                        vendorObj.Country = vendorInputModel.Country;
                        vendorObj.FullAddress = vendorInputModel.FullAddress;
                        vendorObj.Status = "Pending";
                        vendorObj.StatusRemarks = "Your request has been sent to admin.";
                        vendorObj.CreatedBy = vendorInputModel.CreatedBy;
                        vendorObj.CreatedOn = DateTime.Now;

                        await _dbContext.AddAsync(vendorObj);
                    }

                    await _dbContext.SaveChangesAsync();

                    apiResponseModel.Status = true;
                    apiResponseModel.Message = vendorInputModel.Id > 0 ? "Vendor updated successfully" : "Vendor added successfully";
                }

            }

            catch (Exception ex)
            {
                var msg = ex.Message;
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
                        DealingPerson = vendor.DealingPerson,
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
        public async Task<ApiResponseModel> VendorStatusUpdate(int vendorId,int userId, string status, string statusRemarks)
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

        public async Task<ApiResponseModel> VendorLogin(int mobile, string password)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var dbVendor = await _dbContext.tblVendor.Where(x => x.Mobile == mobile).FirstOrDefaultAsync();

                if (dbVendor != null)
                {
                    if(dbVendor.Password != password)
                    {
                        apiResponseModel.Status = false;
                        apiResponseModel.Message = "Incorrect password";
                    }
                    else if (dbVendor.Status == "Approved")
                    {
                        if(dbVendor.Password != password)
                        {
                            apiResponseModel.Status = false;
                            apiResponseModel.Message = "Incorrect password";

                        }
                        apiResponseModel.Status = true;
                        apiResponseModel.Message = "User logged in successfully";
                        apiResponseModel.Response = dbVendor;

                        dbVendor.LastLoginDate = DateTime.Now;
                        await _dbContext.SaveChangesAsync();
                    }
                    else if(dbVendor.Status == "Rejected")
                    {
                        apiResponseModel.Status = false;
                        apiResponseModel.Message = "Sorry, you are rejected by admin.";
                    }
                    else if(dbVendor.Status == "Pending")
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

    }
}
