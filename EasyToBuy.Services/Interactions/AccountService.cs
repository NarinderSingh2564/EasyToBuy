using EasyToBuy.Data;
using EasyToBuy.Data.DBClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

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
                if(checkStateDuplicate != null)
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
                     await  _dbContext.SaveChangesAsync();

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
