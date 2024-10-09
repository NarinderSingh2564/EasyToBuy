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
        public async Task<ApiResponseModel> UserRegistration(UserInputModel userInputModel)
        {
            using (UserService userService = new UserService())
            {
                return await userService.UserRegistration(userInputModel);
            }
        }
        public async Task<IEnumerable<UserModel>> GetUserList()
        {
            using (UserService userService = new UserService())
            {
                return await userService.GetUserList();
            }
        }
        public async Task<ApiResponseModel> UserStatusUpdate(int userId, string statusRemarks)
        {
            using (UserService userService = new UserService())
            {
                return await userService.UserStatusUpdate(userId, statusRemarks);
            }
        }
        public async Task<IEnumerable<SPGetUserOrdersCountById_Result>> GetUserOrdersCount(int userId)
        {
            using (UserService userService = new UserService())
            {
                return await userService.GetUserOrdersCount(userId);
            }
        }


    }
}
