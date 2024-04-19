using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;

namespace EasyToBuy.Repository.Abstract
{
    public interface IAccountRepository
    {
        Task<ApiResponseModel> CheckUser(string mobile, string password);

        Task<ApiResponseModel> GetAddressListByUserId(int userID);

        Task<ApiResponseModel> UserRegistration(UserInputModel userInputModel);

        Task<ApiResponseModel> CountryAddEdit(CountryInputModel countryInputModel);
        Task<IEnumerable<CountryModel>> GetCountryList();
        Task<ApiResponseModel> CountryDelete(int Id);
        Task<IEnumerable<StateModel>> GetStatesList();
        Task<ApiResponseModel> StateAddEdit(StateInputModel stateInputModel);
        Task<ApiResponseModel> StateDelete(int Id);
    }
}
