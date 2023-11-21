using Microsoft.EntityFrameworkCore;

namespace aspnet_crm.Data.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SEYMA;Initial Catalog=aspnet-crm;Integrated Security=True;Trust Server Certificate=True");
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }

    }
}
