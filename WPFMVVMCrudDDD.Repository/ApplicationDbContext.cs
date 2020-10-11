using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMVVMCrudDDD.Domain.Models;

namespace WPFMVVMCrudDDD.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext() : base()
        {
            //this connection string is used for migrations when you use Update-Database command.
            this.Database.Connection.ConnectionString = "server=(LOCAL);database=WPFMVVMCrudDDD_db;trusted_connection=true";
        }
        public ApplicationDbContext(string connString)
        : base(connString)
        {
        }
    }
}
