using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;

namespace EasyToBuy.Repository.Abstract
{
    public interface IAccountRepository
    {
        Task<ApiResponseModel> CheckUser(string mobile, string password);
        Task<ApiResponseModel> CountryAddEdit(CountryInputModel CountryInputModel);
        Task<IEnumerable<CountryModel>> GetCountryList();
        Task<ApiResponseModel> CountryDelete(int countryId);
    }
}
