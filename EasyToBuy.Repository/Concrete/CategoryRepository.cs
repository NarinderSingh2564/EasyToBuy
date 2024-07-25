using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
using EasyToBuy.Repository.Abstract;
using EasyToBuy.Services.Interactions;

namespace EasyToBuy.Repository.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task<IEnumerable<CategoryModel>> GetCategoryList()
        {
            using (CategoryService categoryService = new CategoryService())
            {
                return await categoryService.GetCategoryList();
            }
        }
        public async Task<IEnumerable<CategoryModel>> GetCategoryById(int Id)
        {
            using (CategoryService categoryService = new CategoryService())
            {
                return await categoryService.GetCategoryById(Id);
            }
        }
        public async Task<ApiResponseModel> CategoryAddEdit(CategoryInputModel categoryInputModel)
        {
            using (CategoryService categoryService = new CategoryService())
            {
                return await categoryService.CategoryAddEdit(categoryInputModel);
            }
        }
    }
}
