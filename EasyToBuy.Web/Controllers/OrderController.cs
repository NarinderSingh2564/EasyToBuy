﻿using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.Models;
using EasyToBuy.Repository.Abstract;
using EasyToBuy.Repository.Concrete;
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
        public async Task<ApiResponseModel> PlaceOrder(int customerId)
        {
            var response =  await _orderRepository.PlaceOrder(customerId);
            return response;
        }

        [HttpGet("GetOrdersList")]
        public async Task<IEnumerable<SPGetOrderList_Result>> GetOrdersList(int customerId, string? searchText, string? statusId, DateTime? firstDate, DateTime? secondDate)
        {
            var response = await _orderRepository.GetOrdersList(customerId, searchText, statusId, firstDate, secondDate);

            return response;
        }

        [HttpGet("CustomerOrderStatusUpdate")]
        public async Task<ApiResponseModel> CustomerOrderStatusUpdate(int userId, int orderId, int statusId)
        {
            var response = await _orderRepository.CustomerOrderStatusUpdate(userId, orderId, statusId);

            return response;
        }

        [HttpGet("GetOrderStatusTrackingList")]
        public async Task<IEnumerable<SPGetTrackingStatusListByOrderId_Result>> GetOrderStatusTrackingList(string orderId)
        {
            var response = await _orderRepository.GetOrderStatusTrackingList(orderId);

            return response;
        }
    }
}
