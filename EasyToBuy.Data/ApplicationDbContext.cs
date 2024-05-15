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
        public DbSet<Order> tblCustomerOrder { get; set; }     
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=abcd;Database=EasyToBuyDb;User Id=abcd; Password=abcd;Trusted_Connection=False;TrustServerCertificate=true;Integrated Security=false;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
        }
        public DbSet<SPGetCartDetailsByCustomerId_Result> cartDetailsByCustomerId_Results { get; set; }
        public DbSet<SPGetProductList_Result> productList_Results { get; set; }
        public DbSet<SPGetProductDetailsById_Result> productDetailsById_Results { get; set; }
        public DbSet<SPGetVendorOrdersCountById_Result> vendorOrdersCountById_Results { get; set; }

    }
}
