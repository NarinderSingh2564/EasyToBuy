using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Data.SPClasses
{
    public class SPGetProductRatingReviewByProductId_Result
    {
        [Key]
        public int RatingReviewId { get; set; }
        public int ProductId { get; set; }
        public int Rating {  get; set; }
        public string ReviewTitle {  get; set; }
        public string? ReviewDescription { get; set;}
        public int CustomerId {  get; set; }
        public string CustomerName { get; set; }    
        public string CreatedDate { get; set; }
        public string? ProductImage1 {  get; set; }
        public string? ProductImage2 {  get; set; }
        public string? ProductImage3 {  get; set; }
        
    }
}
