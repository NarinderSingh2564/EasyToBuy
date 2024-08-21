using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;

namespace EasyToBuy.Repository.Abstract
{
    public interface IUserRepository
    {
        Task<ApiResponseModel> VendorRegistration(UserInputModel vendorInputModel);
        Task<IEnumerable<UserModel>> GetVendorList();
        Task<ApiResponseModel> VendorStatusUpdate(int vendorId, int userId, string status, string statusRemarks);
        Task<ApiResponseModel> VendorLogin(string mobile, string password);
        Task<IEnumerable<SPGetVendorOrdersCountById_Result>> GetVendorOrdersCount(int vendorId);
    }
}
