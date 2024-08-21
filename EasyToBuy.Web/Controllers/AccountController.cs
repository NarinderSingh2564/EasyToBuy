using System.Diagnostics.Metrics;
using System.Globalization;
using EasyToBuy.Data.DBClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.CommonModels;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
using EasyToBuy.Models.UIModels;
using EasyToBuy.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            var response = await _accountRepository.CheckUser(loginModel.Mobile, loginModel.Password,loginModel.Role);      

            return response;
        }

        [HttpPost("UserRegistration")]
        public async Task<ApiResponseModel> UserRegistration(CustomerUIModel userUIModel)
        {
            var userInputModel = new CustomerInputModel();

            userInputModel.Id = userUIModel.Id;
            userInputModel.Name = userUIModel.Name;
            userInputModel.Email = userUIModel.Email;
            userInputModel.Mobile = userUIModel.Mobile;
            userInputModel.Password = userUIModel.Password;
            userInputModel.CreatedBy = 1;

            var response = await _accountRepository.UserRegistration(userInputModel);

            return response;
            
        }

        [HttpGet("GetAddressListByUserId")]
        public async Task<IEnumerable<AddressModel>> GetAddressListByUserId(int userID)
        {
            var response = await _accountRepository.GetAddressListByUserId(userID);

            return response;
        }

        [HttpGet("GetAddressTypeList")]
        public async Task<IEnumerable<AddressTypeModel>> GetAddressTypeList()
        {
            var response = await _accountRepository.GetAddressTypeList();

            return response;
        }

        [HttpPost("AddressAddEdit")]
        public async Task<ApiResponseModel> AddressAddEdit(AddressUIModel addressUIModel)
        {
            var addressInputModel = new AddressInputModel();
            
            addressInputModel.Id = addressUIModel.Id;
            addressInputModel.UserId = addressUIModel.UserId;
            addressInputModel.FullAddress = addressUIModel.FullAddress;
            addressInputModel.Pincode = addressUIModel.Pincode;
            addressInputModel.City = addressUIModel.City;
            addressInputModel.State = addressUIModel.State;
            addressInputModel.Country = addressUIModel.Country;
            addressInputModel.AddressTypeId = addressUIModel.AddressTypeId;
            addressInputModel.CreatedBy = addressUIModel.CreatedBy;
            addressInputModel.UpdatedBy = addressUIModel.UpdatedBy;

            var response = await _accountRepository.AddressAddEdit(addressInputModel);
           
            return response;
        }

        [HttpPost("SetDeliveryAddress")]
        public async Task<ApiResponseModel> SetDeliveryAddress(int id, int userId)
        {
            var response = await _accountRepository.SetDeliveryAddress(id, userId);

            return response;
        }

        [HttpGet("GetCustomerAccountProfile")]
        public async Task<CustomerModel> GetCustomerAccountProfile(int userId)
        {
            var objectUser = new CustomerUIModel();

            var response = await _accountRepository.GetCustomerAccountProfile(userId);

            var result = await _accountRepository.GetAddressUserByUserId(userId);

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
