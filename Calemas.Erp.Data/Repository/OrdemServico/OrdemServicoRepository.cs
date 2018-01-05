using Common.Domain.Base;
using Common.Orm;
using Calemas.Erp.Data.Context;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using Calemas.Erp.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;

namespace Calemas.Erp.Data.Repository
{
    public class OrdemServicoRepository : Repository<OrdemServico>, IOrdemServicoRepository
    {
        public OrdemServicoRepository(DbContextCore ctx) : base(ctx)
        {


        }


        public IQueryable<OrdemServico> GetBySimplefilters(OrdemServicoFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
                                .WithBasicFilters(filters)
                                .WithCustomFilters(filters);
            return querybase;
        }

        public async Task<OrdemServico> GetById(OrdemServicoFilter model)
        {
            var _ordemservico = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_ => _.OrdemServicoId == model.OrdemServicoId));

            return _ordemservico;
        }

        public async Task<IEnumerable<dynamic>> GetDataItem(OrdemServicoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.OrdemServicoId

            }));

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(OrdemServicoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.OrdemServicoId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(OrdemServicoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.OrdemServicoId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<OrdemServico> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<OrdemServico> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.OrdemServicoId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.OrdemServicoId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.OrdemServicoId);

            return source;
        }

        protected override IQueryable<OrdemServico> MapperGetByFiltersToDomainFields(IQueryable<OrdemServico> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new OrdemServico
                {

                }).AsQueryable();
            }

            return result.Select(_ => (OrdemServico)_).AsQueryable();

        }

        protected override OrdemServico MapperGetOneToDomainFields(IQueryable<OrdemServico> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new OrdemServico
                {

                };
            }

            return source.SingleOrDefault();
        }

        protected override Expression<Func<OrdemServico, object>>[] DataAgregation(Expression<Func<OrdemServico, object>>[] includes, FilterBase filter)
        {
            return includes.Add(
                _ => _.Agenda.CollectionAgendaColaborador,
                _ => _.Cliente.Condominio,
                _ => _.Cliente.Pessoa,
                _ => _.StatusOrdemServico,
                _ => _.StatusPagamento,
                _ => _.TipoOrdemServico,
                _ => _.Responsavel.Pessoa,
                _ => _.CollectionOrdemServicoInteracao);
        }


    }
}
