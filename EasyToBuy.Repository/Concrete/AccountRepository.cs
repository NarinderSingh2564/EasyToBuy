using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
using EasyToBuy.Repository.Abstract;
using EasyToBuy.Services.Interactions;

namespace EasyToBuy.Repository.Concrete
{
    public class AccountRepository:IAccountRepository
    {

        public async Task<ApiResponseModel> CheckUser(string mobile, string password)
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.CheckUser(mobile, password);
            }
        }
        public async Task<ApiResponseModel> CountryAddEdit(CountryInputModel CountryInputModel)
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.CountryAddEdit(CountryInputModel);
            }
        }
        public async Task<IEnumerable<CountryModel>> GetCountryList()
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.GetCountryList();
            }
        }
        public async Task<ApiResponseModel> CountryDelete(int countryId)
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.CountryDelete(countryId);
            }
        }

    }
}
