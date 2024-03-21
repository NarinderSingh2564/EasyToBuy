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
    public class AccountController : ControllerBase
    {
        private IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("CheckUser")]
        public async Task<ApiResponseModel> CheckUser(string mobile, string password)
        {
            var response = await _accountRepository.CheckUser(mobile, password);

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

        [HttpGet("GetCountryList")]
        public async Task<IEnumerable<CountryModel>> GetCountryList()
        {
            var response = await _accountRepository.GetCountryList();

            return response;
        }

        [HttpPost("CountryDelete{countryId}")]
        public async Task<ApiResponseModel> CountryDelete([FromRoute] int countryId)
        {
            var response = await _accountRepository.CountryDelete(countryId);

            return response;
        }

    }
}
