using EasyToBuy.Data.DBClasses;
using EasyToBuy.Models.SPResults;
using Microsoft.EntityFrameworkCore;

namespace EasyToBuy.Data
{
    public class ApplicationDbContext : DbContext   
    {
        public ApplicationDbContext()
        {

        }
        
        public DbSet<Country> tblCountry { get; set; }
        public DbSet<State> tblState { get; set; }
        public DbSet<City> tblCity { get; set; }
        public DbSet<User> tblUser { get; set; }
        public DbSet<Address> tblAddress  { get; set; }
        public DbSet<Category> tblCategory { get; set; }
        public DbSet<Product> tblProduct { get; set; }
        public DbSet<ProductWeights> tblProductWeight { get; set; } 
        public DbSet<Cart> tblCart { get; set; }
        public DbSet<SPGetCartDetailsByCustomerId_Result> cartDetailsByCustomerId_Results { get; set; }
        public DbSet<SPGetProductDetails_Result> productDetails_Results { get; set; }

        public DbSet<SPGetProductDescriptionByProductId_Result> productDescription_Results { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SG2NWPLS19SQL-v09.mssql.shr.prod.sin2.secureserver.net;Database=EasyToBuyDb;User Id=EasyToBuy_Admin; Password=Bloom@2564;Trusted_Connection=False;TrustServerCertificate=true;Integrated Security=false;");
        }

    }
}
