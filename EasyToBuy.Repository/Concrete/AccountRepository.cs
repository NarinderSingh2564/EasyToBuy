using System.Reflection;
using EasyToBuy.Data.DBClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
using EasyToBuy.Repository.Abstract;
using EasyToBuy.Services.Interactions;

namespace EasyToBuy.Repository.Concrete
{
    public class AccountRepository : IAccountRepository
    {
        public async Task<ApiResponseModel> CheckUser(string username, string password)
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.CheckUser(username, password);
            }
        }
        public async Task<ApiResponseModel> CustomerRegistration(CustomerInputModel customerInputModel)
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.CustomerRegistration(customerInputModel);

            }
        }
        public async Task<IEnumerable<CustomerAddressModel>> GetAddressListByCustomerId(int customerId)
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.GetAddressListByCustomerId(customerId);
            }
        }
        public async Task<IEnumerable<AddressTypeModel>> GetAddressTypeList()
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.GetAddressTypeList();

            }
        }
        public async Task<ApiResponseModel> AddressAddEdit(CustomerAddressInputModel customerAddressInputModel)
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.AddressAddEdit(customerAddressInputModel);

            }
        }
        public async Task<ApiResponseModel> SetDeliveryAddress(int addressId, int customerId)
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.SetDeliveryAddress(addressId, customerId);

            }
        }
        public async Task<CustomerModel> GetCustomerAccountProfile(int CustomerId)
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.GetCustomerAccountProfile(CustomerId);
            }
        }
        public async Task<CustomerAddressModel> GetAddressUserByUserId(int userId)
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.GetAddressUserByUserId(userId);
            }
        }
    }
}