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
        public async Task<ApiResponseModel> CheckUser(string mobile, string password, string role)
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.CheckUser(mobile, password, role);
            }
        }
        public async Task<ApiResponseModel> CustomerRegistration(CustomerInputModel customerInputModel)
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.CustomerRegistration(customerInputModel);

            }
        }
        public async Task<IEnumerable<AddressModel>> GetAddressListByCustomerId(int customerId)
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
        public async Task<ApiResponseModel> AddressAddEdit(AddressInputModel addressInputModel)
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.AddressAddEdit(addressInputModel);

            }
        }
        public async Task<ApiResponseModel> SetDeliveryAddress(int addressId, int CustomerId)
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.SetDeliveryAddress(addressId, CustomerId);

            }
        }
        public async Task<CustomerModel> GetCustomerAccountProfile(int CustomerId)
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.GetCustomerAccountProfile(CustomerId);
            }
        }
        public async Task<AddressModel> GetAddressUserByUserId(int userId)
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.GetAddressUserByUserId(userId);
            }
        }
    }
}