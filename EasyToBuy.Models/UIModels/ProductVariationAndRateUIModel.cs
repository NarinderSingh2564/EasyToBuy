﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Models.UIModels
{
    public class ProductVariationAndRateUIModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductPackingId { get; set; }
        public int Quantity { get; set; }
        public int ProductWeightId { get; set; }
        public decimal MRP { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal PriceAfterDiscount { get; set; }
        public int StockQuantity { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
