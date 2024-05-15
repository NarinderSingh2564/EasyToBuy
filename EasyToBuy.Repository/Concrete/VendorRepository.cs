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
    public class VendorRepository : IVendorRepository
    {
        public async Task<ApiResponseModel> VendorAddEdit(VendorInputModel vendorInputModel)
        {
            using (VendorService vendorService = new VendorService())
            {
                return await vendorService.VendorAddEdit(vendorInputModel);
            }
        }
        public async Task<IEnumerable<VendorModel>> GetVendorList()
        {
            using (VendorService vendorService = new VendorService())
            {
                return await vendorService.GetVendorList();
            }
        }
        public async Task<ApiResponseModel> VendorStatusUpdate(int vendorId, int userId, string status, string statusRemarks)
        {
            using (VendorService vendorService = new VendorService())
            {
                return await vendorService.VendorStatusUpdate(vendorId,userId, status, statusRemarks);
            }
        }
        public async Task<ApiResponseModel> VendorLogin(string mobile, string password)
        {
            using (VendorService vendorService = new VendorService())
            {
                return await vendorService.VendorLogin(mobile,password);
            }
        }

        public async Task<IEnumerable<SPGetVendorOrdersCountById_Result>> GetVendorOrdersCount(int vendorId)
        {
            using (VendorService vendorService = new VendorService())
            {
                return await vendorService.GetVendorOrdersCount(vendorId);
            }
        }


    }
}
