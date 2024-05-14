using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.Models;
using EasyToBuy.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyToBuy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        #region PRIVATE VARIABLES
        private IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        #endregion

        [HttpPost("PlaceOrder")]
        public async Task<ApiResponseModel> PlaceOrder(int userId)
        {

            var response =  await _orderRepository.PlaceOrder(userId);
            return response;
        }
    }
}
