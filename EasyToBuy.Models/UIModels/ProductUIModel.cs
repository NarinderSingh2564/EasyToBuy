﻿namespace EasyToBuy.Models.UIModels
{
    public class ProductUIModel
    {
        public int Id { get; set; }
        public string ProductSku { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ProductShortName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductTimeSpan { get; set; }
        public int CategoryId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
