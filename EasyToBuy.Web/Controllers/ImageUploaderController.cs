using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyToBuy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploaderController : ControllerBase
    {
        [HttpPost("ImageUpload")]
        public ApiResponseModel ImageUpload([FromForm]ImageFileModel imageFileModel )
        {
            ApiResponseModel response = new ApiResponseModel();

            try
            {
                string path = Path.Combine(@"C:\Users\admin\Project\Angular\EasyToBuyFrontEnd\src\assets\images", imageFileModel.fileName);
                using(Stream stream = new FileStream(path, FileMode.Create))
                {
                    imageFileModel.file.CopyTo(stream);
                }
                response.Status = true;
                response.Message = "ImageUpload Successfully";
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
                response.Message = "Error occured please contact with developer";
            }

            return response;
        }
    }
}
