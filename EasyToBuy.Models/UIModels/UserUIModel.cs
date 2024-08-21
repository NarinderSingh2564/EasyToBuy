namespace EasyToBuy.Models.UIModels
{
    public class UserUIModel
    {
        public VendorBasicDetailsUIModel vendorBasicDetailsUIModel { get; set; }
        public VendorCompanyDetailsUIModel vendorCompanyDetailsUIModel { get; set; }
        public VendorBankDetailsUIModel vendorBankDetailsUIModel { get; set; }
        public UserUIModel()
        {
            vendorBasicDetailsUIModel = new VendorBasicDetailsUIModel();
            vendorCompanyDetailsUIModel = new VendorCompanyDetailsUIModel();
            vendorBankDetailsUIModel = new VendorBankDetailsUIModel();
        }
    }
    public class VendorBasicDetailsUIModel
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string IdentificationType { get; set; } = string.Empty;
        public string IdentificationNumber { get; set; } = string.Empty;
        public int Pincode { get; set; }
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
    }
    public class VendorCompanyDetailsUIModel
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
    public class VendorBankDetailsUIModel
    {
        public string AccountHolderName { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string IFSCCode { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
    }
}
