using System.ComponentModel;
using EasyToBuy.Data;
using EasyToBuy.Data.DBClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
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

        public async Task<ApiResponseModel> CheckUser(string mobile , string password)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var dbUser = await _dbContext.tblUser.Where(x=>x.Mobile == mobile).FirstOrDefaultAsync();

                if (dbUser == null)
                {
                    apiResponseModel.Status = false;
                    apiResponseModel.Message = "User not found.";
                }
                else if(dbUser.Password != password)
                {
                    apiResponseModel.Status = false;
                    apiResponseModel.Message = "Incorrect password.";
                }
                else if(!dbUser.IsActive)
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
        
        public async Task<IEnumerable<CountryModel>> GetCountryList()
        {
            var countryList = new List<CountryModel>();

            try
            {
                var dbCountryList = await _dbContext.tblCountry.ToListAsync();
                foreach (var country in dbCountryList)
                {
                    countryList.Add(new CountryModel
                    {
                        Id = country.Id,
                        CountryCode = country.CountryCode,
                        CountryName = country.CountryName,
                        IsActive = country.IsActive
                    });
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return countryList;
        }
        public async Task<ApiResponseModel> CountryAddEdit(CountryInputModel countryInputModel)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var isCountryExists = await _dbContext.tblCountry.Where(x => x.CountryName == countryInputModel.CountryName).FirstOrDefaultAsync();

                if (isCountryExists != null)
                {
                    apiResponseModel.Status = false;
                    apiResponseModel.Message = "This country already exists.";
                }

                else
                {
                    var dbCountry = await _dbContext.tblCountry.Where(x => x.Id == countryInputModel.Id).FirstOrDefaultAsync();

                    if (dbCountry != null)
                    {
                        dbCountry.CountryName = countryInputModel.CountryName;
                        dbCountry.CountryCode = countryInputModel.CountryCode;
                        dbCountry.UpdatedBy = countryInputModel.UpdatedBy;
                        dbCountry.UpdatedOn = DateTime.Now;
                        dbCountry.IsActive = countryInputModel.IsActive;
                    }
                    else
                    {
                        var countryObj = new Country();

                        countryObj.CountryName = countryInputModel.CountryName;
                        countryObj.CountryCode = countryInputModel.CountryCode;
                        countryObj.CreatedBy = countryInputModel.CreatedBy;
                        countryObj.CreatedOn = DateTime.Now;
                        countryObj.IsActive = countryInputModel.IsActive;

                        await _dbContext.AddAsync(countryObj);
                    }

                    await _dbContext.SaveChangesAsync();

                    apiResponseModel.Status = true;
                    apiResponseModel.Message = countryInputModel.Id > 0 ? "Country updated successfully." : "Country added successfully.";
                }

            }

            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return apiResponseModel;
        }
        public async Task<ApiResponseModel> CountryDelete(int countryId)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var dbCountry = await _dbContext.tblCountry.FindAsync(countryId);
                if (dbCountry != null)
                {
                    dbCountry.IsActive = false;
                    await _dbContext.SaveChangesAsync();

                    apiResponseModel.Status = true;
                    apiResponseModel.Message = "Country deleted successfully.";
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
