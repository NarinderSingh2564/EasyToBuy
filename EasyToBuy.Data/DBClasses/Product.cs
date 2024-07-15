﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Data.DBClasses
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Vendor")]
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string ProductName { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string ProductDescription { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string ProductImage { get; set; }

        [ForeignKey("Categorys")]
        public int CategoryId { get; set; }
        public virtual Category Categorys { get; set; }
        public decimal TotalVolume { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string PackingMode { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
