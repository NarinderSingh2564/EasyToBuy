using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;

namespace EasyToBuy.Repository.Abstract
{
    public interface IAccountRepository
    {
        Task<ApiResponseModel> CheckUser(string mobile, string password,string role);
        Task<ApiResponseModel> UserRegistration(CustomerInputModel userInputModel);
        Task<IEnumerable<AddressModel>> GetAddressListByUserId(int userID);
        Task<IEnumerable<AddressTypeModel>> GetAddressTypeList();
        Task<ApiResponseModel> AddressAddEdit(AddressInputModel addressInputModel);
        Task<ApiResponseModel> SetDeliveryAddress(int id, int userId);
        Task<CustomerModel>GetCustomerAccountProfile(int userId);
        Task<AddressModel> GetAddressUserByUserId(int userId);

    }
}
