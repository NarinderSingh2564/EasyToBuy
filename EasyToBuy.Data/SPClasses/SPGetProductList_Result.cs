﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToBuy.Data.SPClasses
{

    [NotMapped]
    public class SPGetProductList_Result
    {
        [Key]
        public int Id { get; set; }

        //public int ProductId { get; set; }
        public int VendorId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int ProductPrice { get; set; }
        public int ProductDiscount { get; set; }
        public decimal ProductDiscountPrice { get; set; }
        public decimal ProductPriceAfterDiscount { get; set; }
        public string ProductImage { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int ProductWeightId { get; set; }
        public bool ShowProductWeight { get; set; }
        public bool IsActive { get; set; }
        public string PackingMode { get; set; } = string.Empty;
        public string ProductWeight { get; set; } = string.Empty;
        public int Quantity { get; set; }

    }
}