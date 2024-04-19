using System.ComponentModel;
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
        public async Task<IEnumerable<StateModel>> GetStatesList()
        {
            var stateModel = new List<StateModel>();

            var dbStateList = await _dbContext.tblState.ToListAsync();

            foreach (var state in dbStateList)
            {
                stateModel.Add(new StateModel
                {
                    Id = state.Id,
                    CountryId = state.CountryId,
                    StateName = state.StateName,
                    //Countrys = state.tblCountry.Countrys,
                    IsActive = state.IsActive,
                });
            }
            return stateModel;
        }
        public async Task<ApiResponseModel> StateAddEdit(StateInputModel stateInputModel)
        {
            var apiresponseModel = new ApiResponseModel();
            try
            {
                var checkStateDuplicate = await _dbContext.tblState.Where(x => x.StateName == stateInputModel.StateName && x.Id != stateInputModel.Id).FirstOrDefaultAsync();
                if (checkStateDuplicate != null)
                {
                    apiresponseModel.Status = false;
                    apiresponseModel.Message = "This State is already exist";
                }
                else
                {
                    var checkStateExist = await _dbContext.tblState.Where(x => x.Id == stateInputModel.Id).FirstOrDefaultAsync();
                    if (checkStateExist != null)
                    {
                        checkStateExist.StateName = stateInputModel.StateName;
                        checkStateExist.CountryId = stateInputModel.CountryId;
                        checkStateExist.UpdatedOn = DateTime.Now;
                        checkStateExist.UpdatedBy = stateInputModel.Id;
                        checkStateExist.IsActive = stateInputModel.IsActive;
                    }
                    else
                    {
                        var objectState = new State();

                        objectState.StateName = stateInputModel.StateName;
                        objectState.CountryId = stateInputModel.CountryId;
                        objectState.CreatedBy = stateInputModel.Id;
                        objectState.CreatedOn = DateTime.Now;
                        objectState.IsActive = stateInputModel.IsActive;

                        await _dbContext.tblState.AddAsync(objectState);
                    }
                    await _dbContext.SaveChangesAsync();

                    apiresponseModel.Status = true;
                    apiresponseModel.Message = stateInputModel.Id <= 0 ? "Add State Successfully" : "State Successfully Updated";

                }
            }
            catch (Exception e)
            {
                var msg = e.Message;
            }
            return apiresponseModel;
        }
        public async Task<ApiResponseModel> StateDelete(int Id)
        {
            var apiresponseModel = new ApiResponseModel();

            try
            {
                var checkStateExist = await _dbContext.tblState.FindAsync(Id);
                if (checkStateExist != null)
                {
                    checkStateExist.IsActive = false;
                }
                await _dbContext.SaveChangesAsync();

                apiresponseModel.Status = true;
                apiresponseModel.Message = "State Successfully Delete.";
            }
            catch (Exception e)
            {
                var msg = e.Message;
            }
            return apiresponseModel;
        }
    }
}
