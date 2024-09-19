using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.CommonModels;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
using EasyToBuy.Models.UIModels;
using EasyToBuy.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EasyToBuy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region PRIVATE VARIABLES
        private IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        #endregion

        [HttpPost("CheckUser")]
        public async Task<ApiResponseModel> CheckUser(LoginModel loginModel)
        {
            var response = await _accountRepository.CheckUser(loginModel.Username, loginModel.Password);      
           
            return response;
        }

        [HttpPost("CustomerRegistration")]
        public async Task<ApiResponseModel> CustomerRegistration(CustomerUIModel customerUIModel)
        {
            var customerInputModel = new CustomerInputModel();

            customerInputModel.Name = customerUIModel.Name;
            customerInputModel.Email = customerUIModel.Email;
            customerInputModel.Mobile = customerUIModel.Mobile;
            customerInputModel.Password = customerUIModel.Password;
            customerInputModel.CreatedBy = 1;

            var response = await _accountRepository.CustomerRegistration(customerInputModel);

            return response;

        }

        [HttpGet("GetAddressListByCustomerId")]
        public async Task<IEnumerable<CustomerAddressModel>> GetAddressListByCustomerId(int customerId)
        {
            var response = await _accountRepository.GetAddressListByCustomerId(customerId);

            return response;
        }

        [HttpGet("GetAddressTypeList")]
        public async Task<IEnumerable<AddressTypeModel>> GetAddressTypeList()
        {
            var response = await _accountRepository.GetAddressTypeList();

            return response;
        }

        [HttpPost("AddressAddEdit")]
        public async Task<ApiResponseModel> AddressAddEdit(CustomerAddressUIModel customerAddressUIModel)
        {
            var customerAddressInputModel = new CustomerAddressInputModel();

            customerAddressInputModel.Id = customerAddressUIModel.Id;
            customerAddressInputModel.CustomerId = customerAddressUIModel.CustomerId;
            customerAddressInputModel.FullAddress = customerAddressUIModel.FullAddress;
            customerAddressInputModel.Pincode = customerAddressUIModel.Pincode;
            customerAddressInputModel.City = customerAddressUIModel.City;
            customerAddressInputModel.State = customerAddressUIModel.State;
            customerAddressInputModel.Country = customerAddressUIModel.Country;
            customerAddressInputModel.AddressTypeId = customerAddressUIModel.AddressTypeId;
            customerAddressInputModel.CreatedBy = customerAddressUIModel.CreatedBy;
            customerAddressInputModel.UpdatedBy = customerAddressUIModel.UpdatedBy;

            var response = await _accountRepository.AddressAddEdit(customerAddressInputModel);

            return response;
        }

        [HttpPost("SetDeliveryAddress")]
        public async Task<ApiResponseModel> SetDeliveryAddress(int addressId, int customerId)
        {
            var response = await _accountRepository.SetDeliveryAddress(addressId, customerId);

            return response;
        }

        [HttpGet("GetCustomerAccountProfile")]
        public async Task<CustomerModel> GetCustomerAccountProfile(int customerId)
        {
            var objectUser = new CustomerUIModel();

            var response = await _accountRepository.GetCustomerAccountProfile(customerId);

            var result = await _accountRepository.GetAddressUserByUserId(customerId);

            //objectUserUI.address.City = userAddress.City;
            //objectUserUI.address.State = userAddress.State;
            //objectUserUI.address.Country = userAddress.Country;
            //objectUserUI.address.FullAddress = userAddress.FullAddress;
            //objectUserUI.address.AddressTypeId = userAddress.AddressTypeId;
            //objectUserUI.address.TypeOfAddress = userAddress.TypeOfAddress;
            //objectUserUI.address.Pincode = userAddress.Pincode;

            return response;

        }

    }
}
