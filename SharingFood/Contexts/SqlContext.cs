using Microsoft.EntityFrameworkCore;
using SharingFood.Models;

namespace SharingFood.Contexts
{
    public class SqlContext : DbContext
    {
        public DbSet<AccountsModel> Accounts { get; set; }
        public DbSet<PostsModel> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=tcp:illunix.database.windows.net,1433;Initial Catalog=sharingfood;Persist Security Info=False;User ID=developer;Password=8FqypJ7QRnw4rG6;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}