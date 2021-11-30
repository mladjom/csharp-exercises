using Microsoft.EntityFrameworkCore;

namespace MiniProject2.Models
{
    class DataContext : DbContext
    {
        private const string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=miniproject;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;" +
            "MultiSubnetFailover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
