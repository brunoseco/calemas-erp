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
            new CorMap(modelBuilder.Entity<Cor>());
            new OrdemServicoMap(modelBuilder.Entity<OrdemServico>());
            new ColaboradorMap(modelBuilder.Entity<Colaborador>());
            new NivelAcessoMap(modelBuilder.Entity<NivelAcesso>());
            new SetorMap(modelBuilder.Entity<Setor>());
            new PrioridadeMap(modelBuilder.Entity<Prioridade>());
            new TipoOrdemServicoMap(modelBuilder.Entity<TipoOrdemServico>());
            new PessoaMap(modelBuilder.Entity<Pessoa>());

        }


    }
}
