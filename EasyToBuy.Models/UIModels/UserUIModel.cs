namespace EasyToBuy.Models.UIModels
{
    public class UserUIModel
    {
        public UserBasicDetailsUIModel userBasicDetailsUIModel { get; set; }
        public UserCompanyDetailsUIModel userCompanyDetailsUIModel { get; set; }
        public UserBankDetailsUIModel userBankDetailsUIModel { get; set; }
        public UserUIModel()
        {
            userBasicDetailsUIModel = new UserBasicDetailsUIModel();
            userCompanyDetailsUIModel = new UserCompanyDetailsUIModel();
            userBankDetailsUIModel = new UserBankDetailsUIModel();
        }
    }
    public class UserBasicDetailsUIModel
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public string IdentificationType { get; set; } = string.Empty;
        public string IdentificationNumber { get; set; } = string.Empty;
        public int Pincode { get; set; }
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
    }
    public class UserCompanyDetailsUIModel
    {
        public string CompanyName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DealingPerson { get; set; } = string.Empty;
        public string GSTIN { get; set; } = string.Empty;
        public int Pincode { get; set; }
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
    }
    public class UserBankDetailsUIModel
    {
        public string AccountHolderName { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string IFSCCode { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
    }
}
