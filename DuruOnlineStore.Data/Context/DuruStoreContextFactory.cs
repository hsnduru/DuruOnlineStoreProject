using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuruOnlineStore.Data.Context
{
    internal class DuruStoreContextFactory : IDesignTimeDbContextFactory<DuruStoreContext>
    {
        public DuruStoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DuruStoreContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DuruOnlineStoreDB;Integrated Security=True;TrustServerCertificate=True;");

            return new DuruStoreContext(optionsBuilder.Options);
        }
    }
}
