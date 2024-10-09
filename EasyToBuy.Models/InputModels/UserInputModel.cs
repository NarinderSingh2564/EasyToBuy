namespace EasyToBuy.Models.InputModels
{
    public class UserInputModel
    {
        public UserBasicDetailsInputModel userBasicDetailsInputModel { get; set; }
        public UserBankDetailsInputModel userBankDetailsInputModel { get; set; }
        public UserCompanyDetailsInputModel userCompanyDetailsInputModel { get; set; }
        public UserInputModel()
        {
            userBasicDetailsInputModel = new UserBasicDetailsInputModel();
            userBankDetailsInputModel = new UserBankDetailsInputModel();
            userCompanyDetailsInputModel = new UserCompanyDetailsInputModel();
        }
    }
    public class UserBasicDetailsInputModel
    {
        public int Id { get; set; }
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
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

    }
    public class UserCompanyDetailsInputModel
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
    public class UserBankDetailsInputModel
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