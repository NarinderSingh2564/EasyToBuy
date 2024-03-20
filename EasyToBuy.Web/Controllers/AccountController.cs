using EasyToBuy.Models.InputModels;
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
            var response = await _accountRepository.StateDelete(Id);
            return Ok(response);
        }

        
    }
}
