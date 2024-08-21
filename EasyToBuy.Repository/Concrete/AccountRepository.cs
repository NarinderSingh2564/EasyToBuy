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
        public async Task<ApiResponseModel> UserRegistration(CustomerInputModel userInputModel)
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.UserRegistration(userInputModel);

            }
        }
        public async Task<IEnumerable<AddressModel>> GetAddressListByUserId(int userID)
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.GetAddressListByUserId(userID);
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
        public async Task<ApiResponseModel> SetDeliveryAddress(int id, int userId)
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.SetDeliveryAddress(id, userId);

            }
        }
        public async Task<CustomerModel> GetCustomerAccountProfile(int userId)
        {
            using (AccountService accountService = new AccountService())
            {
                return await accountService.GetCustomerAccountProfile(userId);
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