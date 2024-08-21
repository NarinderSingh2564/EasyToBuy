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
        Task<ApiResponseModel> UserRegistration(UserInputModel userInputModel);
        Task<IEnumerable<UserModel>> GetUserList();
        Task<ApiResponseModel> UserStatusUpdate(int userId, int customerId, string status, string statusRemarks);
        Task<ApiResponseModel> UserLogin(string mobile, string password);
        Task<IEnumerable<SPGetVendorOrdersCountById_Result>> GetUserOrdersCount(int userId);
    }
}
