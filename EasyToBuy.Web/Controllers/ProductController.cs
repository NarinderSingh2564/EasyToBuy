using EasyToBuy.Data.DBClasses;
using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
using EasyToBuy.Models.UIModels;
using EasyToBuy.Repository.Abstract;
using EasyToBuy.Repository.Concrete;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;

namespace EasyToBuy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region PRIVATE VARIABLES
        private IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        [HttpGet("GetProductList")]
        public async Task<IEnumerable<SPGetProductList_Result>> GetProductList(int categoryId, string? searchText, int vendorId, string role)
        {
            var response = await _productRepository.GetProductList(categoryId, searchText, vendorId, role);

            return response;
        }

        [HttpPost("ProductAddEdit")]
        public async Task<ApiResponseModel> ProductAddEdit([FromForm] ProductUIModel productUIModel)
        {
            var productInputModel = new ProductInputModel();

            var productImage = string.Empty;

            if (productUIModel.ProductImage != null)
            {
                UploadProductImage("Products", productUIModel.ProductImage, out productImage);
            }

            productInputModel.Id = productUIModel.Id;
            productInputModel.VendorId = productUIModel.VendorId;
            productInputModel.ProductName = productUIModel.ProductName;
            productInputModel.MRP = productUIModel.MRP;
            productInputModel.Discount = productUIModel.Discount;
            productInputModel.DiscountPrice = productUIModel.MRP * Decimal.Divide(productUIModel.Discount, 100);
            productInputModel.PriceAfterDiscount = productUIModel.PriceAfterDiscount;
            productInputModel.ProductDescription = productUIModel.ProductDescription;
            productInputModel.ProductImage = productImage;
            productInputModel.CategoryId = productUIModel.CategoryId;
            productInputModel.ProductWeightId = productUIModel.ProductWeightId;
            productInputModel.ShowProductWeight = productUIModel.ShowProductWeight;
            productInputModel.CreatedBy = productUIModel.CreatedBy;
            productInputModel.UpdatedBy = productUIModel.UpdatedBy;
            productInputModel.IsActive = productUIModel.IsActive;

            var response = await _productRepository.ProductAddEdit(productInputModel);

            return response;
        }

        bool UploadProductImage(string folderName, IFormFile productImage, out string productImageName)
        {
            var fileUploadStatus = false;

            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "Images", folderName);

            if (!System.IO.Directory.Exists(pathToSave))
            {
                System.IO.Directory.CreateDirectory(pathToSave);
            }

            productImageName = "https://localhost:7239/ProductImages/Product_" + new Random().Next().ToString() + productImage.FileName.Trim('"').Trim('%').Replace("'", "").Replace(" ","");

            var fullPath = Path.Combine(pathToSave, productImageName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                productImage.CopyTo(stream);
            }

            return fileUploadStatus;
        }


        [HttpGet("GetProductDetailsById")]
        public async Task<IEnumerable<SPGetProductDetailsById_Result>> GetProductDetailsById(int productId)
        {
            var response = await _productRepository.GetProductDetailsById(productId);

            return response;
        }

        [HttpGet("GetProductWeightList")]
        public async Task<IEnumerable<ProductWeightModel>> GetProductWeightList()
        {
            var response = await _productRepository.GetProductWeightList();

            return response;
        }

    }
}