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
            new ClienteMap(modelBuilder.Entity<Cliente>());
            new CondominioMap(modelBuilder.Entity<Condominio>());
            new EnderecoMap(modelBuilder.Entity<Endereco>());
            new StatusClienteMap(modelBuilder.Entity<StatusCliente>());
            new PessoaMap(modelBuilder.Entity<Pessoa>());
            new ColaboradorMap(modelBuilder.Entity<Colaborador>());
            new NivelAcessoMap(modelBuilder.Entity<NivelAcesso>());
            new CorMap(modelBuilder.Entity<Cor>());
            new OrdemServicoMap(modelBuilder.Entity<OrdemServico>());
            new OrdemServicoInteracaoMap(modelBuilder.Entity<OrdemServicoInteracao>());
            new SetorMap(modelBuilder.Entity<Setor>());
            new PrioridadeMap(modelBuilder.Entity<Prioridade>());
            new TipoOrdemServicoMap(modelBuilder.Entity<TipoOrdemServico>());
            new StatusOrdemServicoMap(modelBuilder.Entity<StatusOrdemServico>());
            new InfraestruturaSiteMap(modelBuilder.Entity<InfraestruturaSite>());
            new InfraestruturaPopMap(modelBuilder.Entity<InfraestruturaPop>());
            new FinanceiroMap(modelBuilder.Entity<Financeiro>());
            new PlanoContaMap(modelBuilder.Entity<PlanoConta>());
            new TipoPlanoContaMap(modelBuilder.Entity<TipoPlanoConta>());
            new StatusPagamentoMap(modelBuilder.Entity<StatusPagamento>());
            new CategoriaEstoqueMap(modelBuilder.Entity<CategoriaEstoque>());
            new UnidadeMedidaMap(modelBuilder.Entity<UnidadeMedida>());
            new EstoqueMap(modelBuilder.Entity<Estoque>());
            new EstoqueMovimentacaoMap(modelBuilder.Entity<EstoqueMovimentacao>());
            new EstoqueMovimentacaoColaboradorMap(modelBuilder.Entity<EstoqueMovimentacaoColaborador>());
            new SolicitacaoEstoqueMap(modelBuilder.Entity<SolicitacaoEstoque>());
            new SolicitacaoEstoqueMovimentacaoMap(modelBuilder.Entity<SolicitacaoEstoqueMovimentacao>());
            new StatusSolicitacaoEstoqueMovimentacaoMap(modelBuilder.Entity<StatusSolicitacaoEstoqueMovimentacao>());

        }


    }
}
