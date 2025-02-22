using System.Configuration;
using System.Data.Entity;
using WPFMVVMCrudDDD.Domain.Models;

namespace WPFMVVMCrudDDD.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext() : base()
        {
            //this connection string is used for migrations when you use Update-Database command.
            this.Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public ApplicationDbContext(string connString)
        : base(connString)
        {
        }
    }
}
