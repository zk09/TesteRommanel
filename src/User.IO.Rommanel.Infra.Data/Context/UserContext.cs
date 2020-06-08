using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using User.IO.Rommanel.Infra.Data.Extensions;
using User.IO.Rommanel.Infra.Data.Mapping;

namespace User.IO.Rommanel.Infra.Data.Context
{
    public class UserContext : DbContext
    {
        public DbSet<Domain.Users.User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region FluentAPI
            modelBuilder.HasDefaultSchema("Rommanel");
            modelBuilder.AddConfiguration(new UserMapping());
            #endregion


            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //var config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("connectionStrings.json")
            //    .Build();

            //optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

           optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Usuarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }

}
