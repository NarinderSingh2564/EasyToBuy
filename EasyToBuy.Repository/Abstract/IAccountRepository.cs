using EasyToBuy.Data.DBClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Repository.Abstract
{
    public interface IAccountRepository
    {
        Task<ApiResponseModel> CheckUser(string mobile, string password);
        Task<ApiResponseModel> CountryAddEdit(CountryInputModel CountryInputModel);
        Task<IEnumerable<CountryModel>> GetCountryList();
        Task<ApiResponseModel> CountryDelete(int countryId);
        Task<IEnumerable<StateModel>> GetStatesList();
        Task<ApiResponseModel> StateAddEdit(StateInputModel stateInputModel);
        Task<ApiResponseModel> StateDelete(int Id);
    }
}
