using System.ComponentModel.DataAnnotations;

namespace EasyToBuy.Data.SPClasses
{
    public class SPGetUserOrdersListByUserId_Result
    {
        [Key]
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductCount { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerAddress { get; set; }

    }
}
