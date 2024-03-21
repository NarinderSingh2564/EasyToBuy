namespace EasyToBuy.Models.CommonModel
{
    public class ApiResponseModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Response { get; set; }
    }
}
