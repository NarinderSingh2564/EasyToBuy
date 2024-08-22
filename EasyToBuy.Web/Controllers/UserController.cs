using System.Net;
using System.Net.Mail;
using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
using EasyToBuy.Models.UIModels;
using EasyToBuy.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EasyToBuy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region PRIVATE VARIABLES
        private IUserRepository _userRepository;
        public UserController(IUserRepository vendorRepository)
        {
            _userRepository = vendorRepository;
        }
        #endregion

        [HttpPost("UserRegistration")]
        public async Task<ApiResponseModel> UserRegistration( UserUIModel userUIModel)
        {
            var userInputModel = new UserInputModel();

            userInputModel.userBasicDetailsInputModel.Name = userUIModel.userBasicDetailsUIModel.Name;
            userInputModel.userBasicDetailsInputModel.Email = userUIModel.userBasicDetailsUIModel.Email;
            userInputModel.userBasicDetailsInputModel.Password = userUIModel.userBasicDetailsUIModel.Password;
            userInputModel.userBasicDetailsInputModel.Mobile = userUIModel.userBasicDetailsUIModel.Mobile;
            userInputModel.userBasicDetailsInputModel.Type = userUIModel.userBasicDetailsUIModel.Type;
            userInputModel.userBasicDetailsInputModel.IdentificationType = userUIModel.userBasicDetailsUIModel.IdentificationType;
            userInputModel.userBasicDetailsInputModel.IdentificationNumber = userUIModel.userBasicDetailsUIModel.IdentificationNumber;
            userInputModel.userBasicDetailsInputModel.Pincode = userUIModel.userBasicDetailsUIModel.Pincode;
            userInputModel.userBasicDetailsInputModel.City = userUIModel.userBasicDetailsUIModel.City;
            userInputModel.userBasicDetailsInputModel.State = userUIModel.userBasicDetailsUIModel.State;
            userInputModel.userBasicDetailsInputModel.Country = userUIModel.userBasicDetailsUIModel.Country;
            userInputModel.userBasicDetailsInputModel.FullAddress = userUIModel.userBasicDetailsUIModel.FullAddress;

            userInputModel.userCompanyDetailsInputModel.CompanyName = userUIModel.userCompanyDetailsUIModel.CompanyName;
            userInputModel.userCompanyDetailsInputModel.Description = userUIModel.userCompanyDetailsUIModel.Description;
            userInputModel.userCompanyDetailsInputModel.DealingPerson = userUIModel.userCompanyDetailsUIModel.DealingPerson;
            userInputModel.userCompanyDetailsInputModel.GSTIN = userUIModel.userCompanyDetailsUIModel.GSTIN;
            userInputModel.userCompanyDetailsInputModel.Pincode = userUIModel.userCompanyDetailsUIModel.Pincode;
            userInputModel.userCompanyDetailsInputModel.City = userUIModel.userCompanyDetailsUIModel.City;
            userInputModel.userCompanyDetailsInputModel.State = userUIModel.userCompanyDetailsUIModel.State;
            userInputModel.userCompanyDetailsInputModel.Country = userUIModel.userCompanyDetailsUIModel.Country;
            userInputModel.userCompanyDetailsInputModel.FullAddress = userUIModel.userCompanyDetailsUIModel.FullAddress;

            userInputModel.userBankDetailsInputModel.AccountHolderName = userUIModel.userBankDetailsUIModel.AccountHolderName;
            userInputModel.userBankDetailsInputModel.AccountNumber = userUIModel.userBankDetailsUIModel.AccountNumber;
            userInputModel.userBankDetailsInputModel.IFSCCode = userUIModel.userBankDetailsUIModel.IFSCCode;
            userInputModel.userBankDetailsInputModel.BankName = userUIModel.userBankDetailsUIModel.BankName;
            userInputModel.userBankDetailsInputModel.Branch = userUIModel.userBankDetailsUIModel.Branch;

            var response = await _userRepository.UserRegistration(userInputModel);

            return response;
        }

        [HttpGet("GetUserList")]
        public async Task<IEnumerable<UserModel>> GetUserList()
        {
            var response = await _userRepository.GetUserList();
            return response;
        }

        [HttpPost("UserStatusUpdate")]
        public async Task<ApiResponseModel> UserStatusUpdate(int userId, string status, string statusRemarks)
        {
            var response = await _userRepository.UserStatusUpdate(userId, status, statusRemarks);

            return response;
        }

        [HttpPost("UserLogin")]
        public async Task<ApiResponseModel> UserLogin(string mobile, string password)
        {
            var response = await _userRepository.UserLogin(mobile, password);

            return response;
        }

        [HttpGet("GetUserOrdersCount")]
        public async Task<IEnumerable<SPGetUserOrdersCountById_Result>> GetUserOrdersCount(int userId)
        {
            var response = await _userRepository.GetUserOrdersCount(userId);

            return response;
        }
       
    }
}
