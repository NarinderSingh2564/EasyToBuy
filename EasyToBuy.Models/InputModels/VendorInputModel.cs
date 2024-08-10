namespace EasyToBuy.Models.InputModels
{
    public class VendorInputModel
    {
        public VendorBasicDetailsInputModel vendorBasicDetailsInputModel { get; set; }
        public VendorCompanyDetailsInputModel vendorCompanyDetailsInputModel { get; set; }
        public VendorBankDetailsInputModel vendorBankDetailsInputModel { get; set; }
        public VendorInputModel()
        {
            vendorBasicDetailsInputModel = new VendorBasicDetailsInputModel();
            vendorBankDetailsInputModel = new VendorBankDetailsInputModel();
            vendorCompanyDetailsInputModel = new VendorCompanyDetailsInputModel();
        }
    }
    public class VendorBasicDetailsInputModel
    {
        public int Id { get; set; }
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
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

    }
    public class VendorCompanyDetailsInputModel
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
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

    }
    public class VendorBankDetailsInputModel
    {
        public string AccountHolderName { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string IFSCCode { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}