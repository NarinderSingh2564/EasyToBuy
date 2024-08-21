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
        private IUserRepository _vendorRepository;
        public UserController(IUserRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }
        #endregion

        [HttpPost("VendorRegistration")]
        public async Task<ApiResponseModel> VendorRegistration( VendorUIModel vendorUIModel)
        {
            var vendorInputModel = new VendorInputModel();

            vendorInputModel.vendorBasicDetailsInputModel.Name = vendorUIModel.vendorBasicDetailsUIModel.Name;
            vendorInputModel.vendorBasicDetailsInputModel.Email = vendorUIModel.vendorBasicDetailsUIModel.Email;
            vendorInputModel.vendorBasicDetailsInputModel.Password = vendorUIModel.vendorBasicDetailsUIModel.Password;
            vendorInputModel.vendorBasicDetailsInputModel.Mobile = vendorUIModel.vendorBasicDetailsUIModel.Mobile;
            vendorInputModel.vendorBasicDetailsInputModel.Type = vendorUIModel.vendorBasicDetailsUIModel.Type;
            vendorInputModel.vendorBasicDetailsInputModel.IdentificationType = vendorUIModel.vendorBasicDetailsUIModel.IdentificationType;
            vendorInputModel.vendorBasicDetailsInputModel.IdentificationNumber = vendorUIModel.vendorBasicDetailsUIModel.IdentificationNumber;
            vendorInputModel.vendorBasicDetailsInputModel.Pincode = vendorUIModel.vendorBasicDetailsUIModel.Pincode;
            vendorInputModel.vendorBasicDetailsInputModel.City = vendorUIModel.vendorBasicDetailsUIModel.City;
            vendorInputModel.vendorBasicDetailsInputModel.State = vendorUIModel.vendorBasicDetailsUIModel.State;
            vendorInputModel.vendorBasicDetailsInputModel.Country = vendorUIModel.vendorBasicDetailsUIModel.Country;
            vendorInputModel.vendorBasicDetailsInputModel.FullAddress = vendorUIModel.vendorBasicDetailsUIModel.FullAddress;

            vendorInputModel.vendorCompanyDetailsInputModel.CompanyName = vendorUIModel.vendorCompanyDetailsUIModel.CompanyName;
            vendorInputModel.vendorCompanyDetailsInputModel.Description = vendorUIModel.vendorCompanyDetailsUIModel.Description;
            vendorInputModel.vendorCompanyDetailsInputModel.DealingPerson = vendorUIModel.vendorCompanyDetailsUIModel.DealingPerson;
            vendorInputModel.vendorCompanyDetailsInputModel.GSTIN = vendorUIModel.vendorCompanyDetailsUIModel.GSTIN;
            vendorInputModel.vendorCompanyDetailsInputModel.Pincode = vendorUIModel.vendorCompanyDetailsUIModel.Pincode;
            vendorInputModel.vendorCompanyDetailsInputModel.City = vendorUIModel.vendorCompanyDetailsUIModel.City;
            vendorInputModel.vendorCompanyDetailsInputModel.State = vendorUIModel.vendorCompanyDetailsUIModel.State;
            vendorInputModel.vendorCompanyDetailsInputModel.Country = vendorUIModel.vendorCompanyDetailsUIModel.Country;
            vendorInputModel.vendorCompanyDetailsInputModel.FullAddress = vendorUIModel.vendorCompanyDetailsUIModel.FullAddress;

            vendorInputModel.vendorBankDetailsInputModel.AccountHolderName = vendorUIModel.vendorBankDetailsUIModel.AccountHolderName;
            vendorInputModel.vendorBankDetailsInputModel.AccountNumber = vendorUIModel.vendorBankDetailsUIModel.AccountNumber;
            vendorInputModel.vendorBankDetailsInputModel.IFSCCode = vendorUIModel.vendorBankDetailsUIModel.IFSCCode;
            vendorInputModel.vendorBankDetailsInputModel.BankName = vendorUIModel.vendorBankDetailsUIModel.BankName;
            vendorInputModel.vendorBankDetailsInputModel.Branch = vendorUIModel.vendorBankDetailsUIModel.Branch;

            var response = await _vendorRepository.VendorRegistration(vendorInputModel);

            return response;
        }

        [HttpGet("GetVendorList")]
        public async Task<IEnumerable<VendorModel>> GetVendorList()
        {
            var response = await _vendorRepository.GetVendorList();
            return response;
        }

        [HttpPost("VendorStatusUpdate")]
        public async Task<ApiResponseModel> VendorStatusUpdate(int vendorId, int userId, string status, string statusRemarks)
        {
            var response = await _vendorRepository.VendorStatusUpdate(vendorId, userId, status, statusRemarks);

            return response;
        }

        [HttpPost("VendorLogin")]

        public async Task<ApiResponseModel> VendorLogin(string mobile, string password)
        {
            var response = await _vendorRepository.VendorLogin(mobile, password);

            return response;
        }


        [HttpGet("GetVendorOrdersCount")]
        public async Task<IEnumerable<SPGetVendorOrdersCountById_Result>> GetVendorOrdersCount(int vendorId)
        {
            var response = await _vendorRepository.GetVendorOrdersCount(vendorId);

            return response;
        }
       
    }
}
