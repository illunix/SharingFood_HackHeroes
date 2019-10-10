using Microsoft.EntityFrameworkCore;
using SharingFood.Models;

namespace SharingFood.Contexts
{
    public class SqlContext : DbContext
    {
        public DbSet<AccountsModel> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=tcp:sharingfood.database.windows.net,1433;Initial Catalog=sharingfood;Persist Security Info=False;User ID=developer;Password=gFLFW115!g;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}