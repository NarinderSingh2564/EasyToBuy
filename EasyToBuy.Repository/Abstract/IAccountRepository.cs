using EasyToBuy.Data.DBClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Repository.Abstract
{
    public interface IAccountRepository
    {
        Task<IEnumerable<StateModel>> GetStatesList();
        Task<ApiResponseModel> StateAddEdit(StateInputModel stateInputModel);
        Task<ApiResponseModel> StateDelete(int Id);
    }
}
