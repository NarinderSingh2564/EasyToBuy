﻿using System.ComponentModel.DataAnnotations;

namespace EasyToBuy.Data.SPClasses
{
    public class SPGetOrderList_Result
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public int VariationId { get; set; }
        public string UserName { get; set; }
        public string CustomerName { get; set; }
        public string Mobile { get; set; }
        public string CustomerAddress { get; set; }
        public string OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public string Status { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string ProductWeight { get; set; }
        public string PackingType { get; set; }
        public int Quantity { get; set; }
        public decimal MRP { get; set; }
        public decimal Discount { get; set; }
        public decimal AmountToBePaid { get; set; }



    }
}
