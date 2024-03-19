using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EasyToBuy.Data
{
    public class ApplicationDbContext : DbContext   
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base (options)
        {
                
        }

        public DbSet<User> UserMaster { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-J96KAUR\\SQLEXPRESS;Database=EasyToBuyDb;Trusted_Connection=True;TrustServerCertificate=True;Trusted_Connection=True;");
        }

    }
}
