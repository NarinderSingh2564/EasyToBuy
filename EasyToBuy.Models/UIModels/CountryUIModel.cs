using EasyToBuy.Models.Models;

namespace EasyToBuy.Models.UIModels
{
    public class CountryUIModel
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

        //public Task<List<CountryModel>> CountryList { get; set; } 

        //public CountryUIModel()
        //{
        //    //CountryList = new Task<List<CountryModel>>();
        //}
    }
}
