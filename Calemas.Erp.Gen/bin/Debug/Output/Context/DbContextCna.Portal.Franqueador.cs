using Microsoft.EntityFrameworkCore;
using Calemas.Erp.Data.Map;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Context
{
    public class DbContextCalemas.Erp : DbContext
    {

        public DbContextCalemas.Erp(DbContextOptions<DbContextCalemas.Erp> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                        new BancoMap(modelBuilder.Entity<Banco>());

        }


    }
}
