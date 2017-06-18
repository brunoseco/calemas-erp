using Microsoft.EntityFrameworkCore;
using Calemas.Erp.Data.Map;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Context
{
    public class DbContextCore : DbContext
    {

        public DbContextCore(DbContextOptions<DbContextCore> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                        new OrdemServicoMap(modelBuilder.Entity<OrdemServico>());
            new PessoaMap(modelBuilder.Entity<Pessoa>());
            new ColaboradorMap(modelBuilder.Entity<Colaborador>());

        }


    }
}
