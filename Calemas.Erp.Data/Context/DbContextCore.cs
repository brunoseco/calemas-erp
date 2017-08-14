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
            new AgendaMap(modelBuilder.Entity<Agenda>());
            new AgendaColaboradorMap(modelBuilder.Entity<AgendaColaborador>());
            new PessoaMap(modelBuilder.Entity<Pessoa>());
            new ColaboradorMap(modelBuilder.Entity<Colaborador>());
            new NivelAcessoMap(modelBuilder.Entity<NivelAcesso>());
            new CorMap(modelBuilder.Entity<Cor>());
            new OrdemServicoMap(modelBuilder.Entity<OrdemServico>());
            new SetorMap(modelBuilder.Entity<Setor>());
            new PrioridadeMap(modelBuilder.Entity<Prioridade>());
            new TipoOrdemServicoMap(modelBuilder.Entity<TipoOrdemServico>());
            new FinanceiroMap(modelBuilder.Entity<Financeiro>());
            new PlanoContaMap(modelBuilder.Entity<PlanoConta>());
            new TipoPlanoContaMap(modelBuilder.Entity<TipoPlanoConta>());
            new CategoriaEstoqueMap(modelBuilder.Entity<CategoriaEstoque>());
            new UnidadeMedidaMap(modelBuilder.Entity<UnidadeMedida>());
            new EstoqueMap(modelBuilder.Entity<Estoque>());
            new EstoqueMovimentacaoMap(modelBuilder.Entity<EstoqueMovimentacao>());

        }


    }
}
