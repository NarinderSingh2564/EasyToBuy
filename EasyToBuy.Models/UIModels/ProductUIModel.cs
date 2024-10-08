﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EasyToBuy.Models.UIModels
{
    public class ProductUIModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public IFormFile? ProductImage { get; set; }
        public string? ProductImageName { get; set; }
        public int CategoryId { get; set; }
        public decimal TotalVolume { get; set; }
        public int PackingModeId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}