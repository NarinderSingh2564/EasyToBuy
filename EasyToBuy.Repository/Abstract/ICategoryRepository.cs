using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;

namespace EasyToBuy.Repository.Abstract
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryModel>> GetCategoryList();
        Task<IEnumerable<CategoryModel>> GetCategoryById(int Id);
        Task<ApiResponseModel> CategoryAddEdit(CategoryInputModel categoryInputModel);
        Task<ApiResponseModel> CategoryDelete(int Id);
    }
}
