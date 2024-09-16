using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyToBuy.Data;
using EasyToBuy.Data.DBClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyToBuy.Services.Interactions
{
    public class CategoryService : IDisposable
    {
        #region Private Variables

        private ApplicationDbContext _dbContext;

        private Component component = new Component();
        private bool disposed = false;
        private IntPtr handle;

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    component.Dispose();
                CloseHandle(handle);
                handle = IntPtr.Zero;
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        #endregion

        #region Constructor

        public CategoryService()
        {
            _dbContext = new ApplicationDbContext();
        }

        #endregion

        #region Destructor

        ~CategoryService()
        {
            Dispose(false);
        }

        #endregion
        public async Task<IEnumerable<CategoryModel>> GetCategoryList()
        {
            var categoryList = new List<CategoryModel>();

            try
            {
                var dbCategoryList = await _dbContext.tblCategory.Include(x=>x.ProductPackingMode).ToListAsync();
                foreach (var category in dbCategoryList)
                {
                    categoryList.Add(new CategoryModel
                    {
                        Id = category.Id,
                        CategoryName = category.CategoryName,
                        PackingModeId = category.PackingModeId,
                        PackingMode = category.ProductPackingMode.PackingMode,
                        IsActive = category.IsActive,
                    });
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return categoryList;
        }
        //public async Task<IEnumerable<CategoryModel>> GetCategoryById(int Id)
        //{
        //    var categoryById = new List<CategoryModel>();

        //    try
        //    {
        //        var dbCategoryById = await _dbContext.tblCategory.Include(x => x.ProductPackingMode).Where(x => x.Id == Id && x.IsActive == true).ToListAsync();
        //        foreach (var category in dbCategoryById)
        //        {
        //            categoryById.Add(new CategoryModel
        //            {
        //                Id = category.Id,
        //                CategoryName = category.CategoryName,
        //                PackingModeId = category.PackingModeId,
        //                PackingMode = category.ProductPackingMode.PackingMode,
        //                IsActive = category.IsActive,
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var msg = ex.Message;
        //    }

        //    return categoryById;
        //}
        public async Task<ApiResponseModel> CategoryAddEdit(CategoryInputModel categoryInputModel)
        {
            var apiResponseModel = new ApiResponseModel();
            try
            {
                var dbCategory = await _dbContext.tblCategory.Where(x => x.Id == categoryInputModel.Id).FirstOrDefaultAsync();

                if (dbCategory != null)
                {
                    dbCategory.CategoryName = categoryInputModel.CategoryName;
                    dbCategory.PackingModeId = categoryInputModel.PackingModeId;
                    dbCategory.UpdatedBy = categoryInputModel.UpdatedBy;
                    dbCategory.UpdatedOn = DateTime.Now;
                    dbCategory.IsActive = categoryInputModel.IsActive;
                }
                else
                {
                    var categoryObj = new Category();

                    categoryObj.CategoryName = categoryInputModel.CategoryName;
                    categoryObj.PackingModeId = categoryInputModel.PackingModeId;
                    categoryObj.CreatedBy = categoryInputModel.CreatedBy;
                    categoryObj.CreatedOn = DateTime.Now;
                    categoryObj.IsActive = categoryInputModel.IsActive;

                    await _dbContext.AddAsync(categoryObj);
                }

                await _dbContext.SaveChangesAsync();

                apiResponseModel.Status = true;
                apiResponseModel.Message = categoryInputModel.Id > 0 ? "Category updated successfully." : "Category added successfully.";
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return apiResponseModel;
        }
    }
}
