using EasyToBuy.Data.DBClasses;
using EasyToBuy.Data.SPClasses;
using Microsoft.EntityFrameworkCore;

namespace EasyToBuy.Data
{
    public class ApplicationDbContext : DbContext   
    {
        public ApplicationDbContext()
        {

        }
        public DbSet<Address> tblAddress  { get; set; }
        public DbSet<AddressType> tblAddressType { get; set; }
        public DbSet<Vendor> tblVendor { get; set; }
        public DbSet<User> tblUser { get; set; }
        public DbSet<Category> tblCategory { get; set; }
        public DbSet<Product> tblProduct { get; set; }
        public DbSet<ProductWeights> tblProductWeight { get; set; } 
        public DbSet<Cart> tblCart { get; set; }
        public DbSet<OrderStatus> tblOrderStatus { get; set; }
        public DbSet<CustomerOrder> tblCustomerOrder { get; set; }     
        public DbSet<CustomerOrderStatusLog> tblCustomerOrderStatusLog { get; set; }     
        public DbSet<ProductPacking> tblProductPacking { get; set; }
        public DbSet<ProductVariationAndRate> tblProductVariationAndRate { get; set; }
        public DbSet<ProductImages> tblProductImages { get; set; }
        public DbSet<ProductSpecification> tblProductSpecification { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SG2NWPLS19SQL-v09.mssql.shr.prod.sin2.secureserver.net;Database=EasyToBuyDb;User Id=EasyToBuyAdmin; Password=Admin@2564;Trusted_Connection=False;TrustServerCertificate=true;Integrated Security=false;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
        }
        public DbSet<SPGetCartDetailsByCustomerId_Result> cartDetailsByCustomerId_Results { get; set; }
        public DbSet<SPGetProductList_Result> productList_Results { get; set; }
        public DbSet<SPGetProductDetailsById_Result> productDetailsById_Results { get; set; }
        public DbSet<SPGetVendorOrdersCountById_Result> vendorOrdersCountById_Results { get; set; }
        public DbSet<SPGetOrderList_Result> orderList_Results { get; set; }
        public DbSet<SPGetTrackingStatusListByOrderId_Result> getTrackingStatusListByOrderId_Results { get; set; }

    }
}
