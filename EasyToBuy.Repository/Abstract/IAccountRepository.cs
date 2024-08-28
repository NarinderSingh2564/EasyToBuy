using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;

namespace EasyToBuy.Repository.Abstract
{
    public interface IAccountRepository
    {
        Task<ApiResponseModel> CheckUser(string username, string password);
        Task<ApiResponseModel> CustomerRegistration(CustomerInputModel customerInputModel);
        Task<IEnumerable<AddressModel>> GetAddressListByCustomerId(int customerId);
        Task<IEnumerable<AddressTypeModel>> GetAddressTypeList();
        Task<ApiResponseModel> AddressAddEdit(AddressInputModel addressInputModel);
        Task<ApiResponseModel> SetDeliveryAddress(int addressId, int customerId);
        Task<CustomerModel> GetCustomerAccountProfile(int customerId);
        Task<AddressModel> GetAddressUserByUserId(int userId);

    }
}
