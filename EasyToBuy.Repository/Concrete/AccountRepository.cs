using EasyToBuy.Data.DBClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Model;
using EasyToBuy.Repository.Abstract;
using EasyToBuy.Services.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Repository.Concrete
{
    public class AccountRepository:IAccountRepository
    {
        public async Task<IEnumerable<StateModel>> GetStatesList() 
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.GetStatesList();
            }
        }
        public async Task<ApiResponseModel> StateAddEdit(StateInputModel stateInputModel)
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.StateAddEdit(stateInputModel);
            }
        }
        public async Task<ApiResponseModel> StateDelete(int Id)
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.StateDelete(Id);
            }
        }

    }
}
