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
            var response = await _accountRepository.CheckUser(loginModel.Mobile, loginModel.Password);

            return response;
        }


        [HttpGet("GetAddressListByUserId")]
        public async Task<ApiResponseModel> GetAddressListByUserId(int userID)
        {
            var response = await _accountRepository.GetAddressListByUserId(userID);

            return response;
        }
        

        [HttpPost("UserRegistration")]

        public async Task<ApiResponseModel> UserRegistration(UserUIModel userUIModel)
        {
            var userInputModel = new UserInputModel();

            userInputModel.Id = userUIModel.Id;
            userInputModel.FullName = userUIModel.FullName;
            userInputModel.Email = userUIModel.Email;
            userInputModel.Mobile = userUIModel.Mobile;
            userInputModel.Password = userUIModel.Password;
            userInputModel.CreatedBy = 1;

            var response = await _accountRepository.UserRegistration(userInputModel);

            return response;
        }


        [HttpGet("GetCountryList")]
        public async Task<IEnumerable<CountryModel>> GetCountryList()
        {
            var response = await _accountRepository.GetCountryList();

            return response;
        }


        [HttpPost("CountryAddEdit")]
        public async Task<ApiResponseModel> CountryAddEdit(CountryUIModel countryUIModel)
        {
            var countryInputModel = new CountryInputModel();

            countryInputModel.Id = countryUIModel.Id;
            countryInputModel.CountryName = countryUIModel.CountryName;
            countryInputModel.CountryCode = countryUIModel.CountryCode;
            countryInputModel.UpdatedBy = countryUIModel.UpdatedBy;
            countryInputModel.CreatedBy = countryUIModel.CreatedBy;
            countryInputModel.IsActive = countryUIModel.IsActive;

            var response =  await _accountRepository.CountryAddEdit(countryInputModel);

            return  response;
        }


        [HttpPost("CountryDelete{countryId}")]
        public async Task<ApiResponseModel> CountryDelete([FromRoute] int Id)
        {
            var response = await _accountRepository.CountryDelete(Id);

            return response;
        }


        [HttpGet("GetStatesList")]
        public async Task<IActionResult> GetStatesList()
        {
            var response = await _accountRepository.GetStatesList();

            return Ok(response);
        }


        [HttpPost("StateAddEdit")]
        public async Task<IActionResult> StateAddEdit(StateUIModel stateUIModel)
        {
            var stateInputModel = new StateInputModel();

            stateInputModel.Id = stateUIModel.Id;
            stateInputModel.CountryId = stateUIModel.CountryId;
            stateInputModel.StateName = stateUIModel.StateName;
            stateInputModel.IsActive = stateUIModel.IsActive;

            var response = await _accountRepository.StateAddEdit(stateInputModel);

            return Ok(response);
        }


        [HttpPost("StateDelete{Id}")]
        public async Task<IActionResult> StateDelete([FromRoute]int Id)
        {
            var kk = string.Empty;
            var response = await _accountRepository.StateDelete(Id);

            return Ok(response);
        }

    }
}
