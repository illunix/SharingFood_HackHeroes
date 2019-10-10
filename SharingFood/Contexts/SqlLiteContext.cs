using Microsoft.EntityFrameworkCore;
using SharingFood.Models;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace SharingFood.Contexts
{
    public class SqlLiteContext : DbContext
    {
        public DbSet<AccountModel> Account { get; set; }

        private string dbPath;

        public SqlLiteContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Device.OS == TargetPlatform.iOS)
            {
                dbPath = Path.Combine(System.Environment.GetFolderPath
                    (System.Environment.SpecialFolder.MyDocuments), "..", "Library", "sharingfood.db");
            }
            else
            {
                dbPath = Path.Combine(System.Environment.GetFolderPath
                    (System.Environment.SpecialFolder.Personal), "sharingfood.db");
            }

            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountModel>().ToTable("Account");
        }
    }
}
