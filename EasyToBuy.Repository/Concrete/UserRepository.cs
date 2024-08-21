using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EasyToBuy.Data.DBClasses;
using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
using EasyToBuy.Repository.Abstract;
using EasyToBuy.Services.Interactions;

namespace EasyToBuy.Repository.Concrete
{
    public class UserRepository : IUserRepository
    {
        public async Task<ApiResponseModel> VendorRegistration(VendorInputModel vendorInputModel)
        {
            using (UserService vendorService = new UserService())
            {
                return await vendorService.VendorRegistration(vendorInputModel);
            }
        }
        public async Task<IEnumerable<VendorModel>> GetVendorList()
        {
            using (UserService vendorService = new UserService())
            {
                return await vendorService.GetVendorList();
            }
        }
        public async Task<ApiResponseModel> VendorStatusUpdate(int vendorId, int userId, string status, string statusRemarks)
        {
            using (UserService vendorService = new UserService())
            {
                return await vendorService.VendorStatusUpdate(vendorId,userId, status, statusRemarks);
            }
        }
        public async Task<ApiResponseModel> VendorLogin(string mobile, string password)
        {
            using (UserService vendorService = new UserService())
            {
                return await vendorService.VendorLogin(mobile,password);
            }
        }

        public async Task<IEnumerable<SPGetVendorOrdersCountById_Result>> GetVendorOrdersCount(int vendorId)
        {
            using (UserService vendorService = new UserService())
            {
                return await vendorService.GetVendorOrdersCount(vendorId);
            }
        }


    }
}
