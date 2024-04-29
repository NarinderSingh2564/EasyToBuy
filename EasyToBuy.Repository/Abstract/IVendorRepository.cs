using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;

namespace EasyToBuy.Repository.Abstract
{
    public interface IVendorRepository
    {
        Task<ApiResponseModel> VendorAddEdit(VendorInputModel vendorInputModel);
        Task<IEnumerable<VendorModel>> GetVendorList();
        Task<ApiResponseModel> VendorStatusUpdate(int vendorId, int userId, string status, string statusRemarks);
        Task<ApiResponseModel> VendorLogin(int mobile, string password);

    }
}
