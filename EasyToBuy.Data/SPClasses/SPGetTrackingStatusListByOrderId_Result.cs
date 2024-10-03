namespace EasyToBuy.Data.SPClasses
{
    public class SPGetTrackingStatusListByOrderId_Result
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public bool IsPending { get; set; }
        public string? statusDate { get; set; }
    }
}