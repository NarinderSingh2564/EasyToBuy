using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
using EasyToBuy.Models.UIModels;
using EasyToBuy.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyToBuy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        #region PRIVATE VARIABLES
        private ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        #endregion

        [HttpGet("GetCategoryList")]
        public async Task<IEnumerable<CategoryModel>> GetCategoryList()
        {
            var response = await _categoryRepository.GetCategoryList();

            return response;
        }

        [HttpGet("GetCategoryById")]
        public async Task<IEnumerable<CategoryModel>> GetCategoryById(int Id)
        {
            var response = await _categoryRepository.GetCategoryById(Id);

            return response;
        }

        [HttpPost("CategoryAddEdit")]
        public async Task<ApiResponseModel> CategoryAddEdit(CategoryUIModel categoryUIModel)
        {
            var categoryInputModel = new CategoryInputModel();

            categoryInputModel.Id = categoryUIModel.Id;
            categoryInputModel.CategoryName = categoryUIModel.CategoryName;
            categoryInputModel.PackingMode = categoryUIModel.PackingMode;
            categoryInputModel.CreatedBy = categoryUIModel.CreatedBy;
            categoryInputModel.UpdatedBy = categoryUIModel.UpdatedBy;
            categoryInputModel.IsActive = categoryUIModel.IsActive;

            var response = await _categoryRepository.CategoryAddEdit(categoryInputModel);

            return response;
        }

     
    }
}
