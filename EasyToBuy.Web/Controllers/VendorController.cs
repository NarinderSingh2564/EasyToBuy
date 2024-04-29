using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
using EasyToBuy.Models.UIModels;
using EasyToBuy.Repository.Abstract;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyToBuy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        #region PRIVATE VARIABLES
        private IVendorRepository _vendorRepository;
        public VendorController(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }
        #endregion

        [HttpPost("VendorAddEdit")]
        public async Task<ApiResponseModel> VendorAddEdit(VendorUIModel vendorUIModel)
        {
            var vendorInputModel = new VendorInputModel();

            vendorInputModel.Id = vendorUIModel.Id;
            vendorInputModel.Name = vendorUIModel.Name;
            vendorInputModel.Email = vendorUIModel.Email;
            vendorInputModel.Password = vendorUIModel.Password;
            vendorInputModel.Mobile = vendorUIModel.Mobile;
            vendorInputModel.DealingPerson = vendorUIModel.DealingPerson;
            vendorInputModel.Pincode = vendorUIModel.Pincode;
            vendorInputModel.City = vendorUIModel.City;
            vendorInputModel.State = vendorUIModel.State;
            vendorInputModel.Country = vendorUIModel.Country;
            vendorInputModel.FullAddress = vendorUIModel.FullAddress;
            vendorInputModel.CreatedBy = vendorUIModel.CreatedBy;
            vendorInputModel.UpdatedBy = vendorUIModel.UpdatedBy;   
          
            var response = await _vendorRepository.VendorAddEdit(vendorInputModel);

            return response;
        }

        [HttpGet("GetVendorList")]
        public async Task<IEnumerable<VendorModel>> GetVendorList()
        {
            var response = await _vendorRepository.GetVendorList();
            return response;
        }

        [HttpPost("VendorStatusUpdate")]
        public async Task<ApiResponseModel> VendorStatusUpdate(int vendorId, int userId ,string status, string statusRemarks)
        {
            var response = await _vendorRepository.VendorStatusUpdate(vendorId,userId, status, statusRemarks);

            return response;
        }

        [HttpPost("VendorLogin")]

        public async Task<ApiResponseModel> VendorLogin(int mobile, string password)
        {
            var response = await _vendorRepository.VendorLogin(mobile, password);
            return response;
        }
    }
}
