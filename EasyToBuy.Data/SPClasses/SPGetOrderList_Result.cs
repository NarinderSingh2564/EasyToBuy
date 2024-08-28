using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string UserName { get; set; }
        public string CustomerName { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
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
