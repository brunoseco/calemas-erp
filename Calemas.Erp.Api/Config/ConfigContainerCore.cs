using Common.Cache;
using Common.Domain.Interfaces;
using Common.Orm;
using Microsoft.Extensions.DependencyInjection;
using Calemas.Erp.Application;
using Calemas.Erp.Application.Interfaces;
using Calemas.Erp.Data.Context;
using Calemas.Erp.Data.Repository;
using Calemas.Erp.Domain.Interfaces.Repository;
using Calemas.Erp.Domain.Interfaces.Services;
using Calemas.Erp.Domain.Services;

namespace Calemas.Erp.Api
{
    public static partial class ConfigContainerCore
    {

        public static void Config(IServiceCollection services)
        {
            services.AddScoped<ICache, RedisComponent>();
            services.AddScoped<IUnitOfWork, UnitOfWork<DbContextCore>>();
            
			services.AddScoped<IAgendaApplicationService, AgendaApplicationService>();
			services.AddScoped<IAgendaService, AgendaService>();
			services.AddScoped<IAgendaRepository, AgendaRepository>();

			services.AddScoped<IAgendaColaboradorApplicationService, AgendaColaboradorApplicationService>();
			services.AddScoped<IAgendaColaboradorService, AgendaColaboradorService>();
			services.AddScoped<IAgendaColaboradorRepository, AgendaColaboradorRepository>();

			services.AddScoped<IClienteApplicationService, ClienteApplicationService>();
			services.AddScoped<IClienteService, ClienteService>();
			services.AddScoped<IClienteRepository, ClienteRepository>();

			services.AddScoped<ICondominioApplicationService, CondominioApplicationService>();
			services.AddScoped<ICondominioService, CondominioService>();
			services.AddScoped<ICondominioRepository, CondominioRepository>();

			services.AddScoped<IEnderecoApplicationService, EnderecoApplicationService>();
			services.AddScoped<IEnderecoService, EnderecoService>();
			services.AddScoped<IEnderecoRepository, EnderecoRepository>();

			services.AddScoped<IStatusClienteApplicationService, StatusClienteApplicationService>();
			services.AddScoped<IStatusClienteService, StatusClienteService>();
			services.AddScoped<IStatusClienteRepository, StatusClienteRepository>();

			services.AddScoped<IPessoaApplicationService, PessoaApplicationService>();
			services.AddScoped<IPessoaService, PessoaService>();
			services.AddScoped<IPessoaRepository, PessoaRepository>();

			services.AddScoped<IColaboradorApplicationService, ColaboradorApplicationService>();
			services.AddScoped<IColaboradorService, ColaboradorService>();
			services.AddScoped<IColaboradorRepository, ColaboradorRepository>();

			services.AddScoped<INivelAcessoApplicationService, NivelAcessoApplicationService>();
			services.AddScoped<INivelAcessoService, NivelAcessoService>();
			services.AddScoped<INivelAcessoRepository, NivelAcessoRepository>();

			services.AddScoped<ICorApplicationService, CorApplicationService>();
			services.AddScoped<ICorService, CorService>();
			services.AddScoped<ICorRepository, CorRepository>();

			services.AddScoped<IOrdemServicoApplicationService, OrdemServicoApplicationService>();
			services.AddScoped<IOrdemServicoService, OrdemServicoService>();
			services.AddScoped<IOrdemServicoRepository, OrdemServicoRepository>();

			services.AddScoped<IOrdemServicoInteracaoApplicationService, OrdemServicoInteracaoApplicationService>();
			services.AddScoped<IOrdemServicoInteracaoService, OrdemServicoInteracaoService>();
			services.AddScoped<IOrdemServicoInteracaoRepository, OrdemServicoInteracaoRepository>();

			services.AddScoped<ISetorApplicationService, SetorApplicationService>();
			services.AddScoped<ISetorService, SetorService>();
			services.AddScoped<ISetorRepository, SetorRepository>();

			services.AddScoped<IPrioridadeApplicationService, PrioridadeApplicationService>();
			services.AddScoped<IPrioridadeService, PrioridadeService>();
			services.AddScoped<IPrioridadeRepository, PrioridadeRepository>();

			services.AddScoped<ITipoOrdemServicoApplicationService, TipoOrdemServicoApplicationService>();
			services.AddScoped<ITipoOrdemServicoService, TipoOrdemServicoService>();
			services.AddScoped<ITipoOrdemServicoRepository, TipoOrdemServicoRepository>();

			services.AddScoped<IStatusOrdemServicoApplicationService, StatusOrdemServicoApplicationService>();
			services.AddScoped<IStatusOrdemServicoService, StatusOrdemServicoService>();
			services.AddScoped<IStatusOrdemServicoRepository, StatusOrdemServicoRepository>();

			services.AddScoped<IFinanceiroApplicationService, FinanceiroApplicationService>();
			services.AddScoped<IFinanceiroService, FinanceiroService>();
			services.AddScoped<IFinanceiroRepository, FinanceiroRepository>();

			services.AddScoped<IPlanoContaApplicationService, PlanoContaApplicationService>();
			services.AddScoped<IPlanoContaService, PlanoContaService>();
			services.AddScoped<IPlanoContaRepository, PlanoContaRepository>();

			services.AddScoped<ITipoPlanoContaApplicationService, TipoPlanoContaApplicationService>();
			services.AddScoped<ITipoPlanoContaService, TipoPlanoContaService>();
			services.AddScoped<ITipoPlanoContaRepository, TipoPlanoContaRepository>();

			services.AddScoped<ICategoriaEstoqueApplicationService, CategoriaEstoqueApplicationService>();
			services.AddScoped<ICategoriaEstoqueService, CategoriaEstoqueService>();
			services.AddScoped<ICategoriaEstoqueRepository, CategoriaEstoqueRepository>();

			services.AddScoped<IUnidadeMedidaApplicationService, UnidadeMedidaApplicationService>();
			services.AddScoped<IUnidadeMedidaService, UnidadeMedidaService>();
			services.AddScoped<IUnidadeMedidaRepository, UnidadeMedidaRepository>();

			services.AddScoped<IEstoqueApplicationService, EstoqueApplicationService>();
			services.AddScoped<IEstoqueService, EstoqueService>();
			services.AddScoped<IEstoqueRepository, EstoqueRepository>();

			services.AddScoped<IEstoqueMovimentacaoApplicationService, EstoqueMovimentacaoApplicationService>();
			services.AddScoped<IEstoqueMovimentacaoService, EstoqueMovimentacaoService>();
			services.AddScoped<IEstoqueMovimentacaoRepository, EstoqueMovimentacaoRepository>();

			services.AddScoped<ISolicitacaoEstoqueMovimentacaoApplicationService, SolicitacaoEstoqueMovimentacaoApplicationService>();
			services.AddScoped<ISolicitacaoEstoqueMovimentacaoService, SolicitacaoEstoqueMovimentacaoService>();
			services.AddScoped<ISolicitacaoEstoqueMovimentacaoRepository, SolicitacaoEstoqueMovimentacaoRepository>();

			services.AddScoped<IStatusSolicitacaoEstoqueMovimentacaoApplicationService, StatusSolicitacaoEstoqueMovimentacaoApplicationService>();
			services.AddScoped<IStatusSolicitacaoEstoqueMovimentacaoService, StatusSolicitacaoEstoqueMovimentacaoService>();
			services.AddScoped<IStatusSolicitacaoEstoqueMovimentacaoRepository, StatusSolicitacaoEstoqueMovimentacaoRepository>();



            RegisterOtherComponents(services);
        }
    }
}
