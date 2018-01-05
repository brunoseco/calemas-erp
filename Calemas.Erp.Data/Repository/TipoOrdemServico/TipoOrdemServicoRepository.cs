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
    public class TipoOrdemServicoRepository : Repository<TipoOrdemServico>, ITipoOrdemServicoRepository
    {
        public TipoOrdemServicoRepository(DbContextCore ctx) : base(ctx)
        {


        }


        public IQueryable<TipoOrdemServico> GetBySimplefilters(TipoOrdemServicoFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
                                .WithBasicFilters(filters)
                                .WithCustomFilters(filters);
            return querybase;
        }

        public async Task<TipoOrdemServico> GetById(TipoOrdemServicoFilter model)
        {
            var _tipoordemservico = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_ => _.TipoOrdemServicoId == model.TipoOrdemServicoId));

            return _tipoordemservico;
        }

        public async Task<IEnumerable<dynamic>> GetDataItem(TipoOrdemServicoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TipoOrdemServicoId,
                Name = _.Setor.Nome + " - " + _.Nome + " - " + _.Prioridade.Nome
            }));

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(TipoOrdemServicoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TipoOrdemServicoId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(TipoOrdemServicoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TipoOrdemServicoId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<TipoOrdemServico> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<TipoOrdemServico> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.TipoOrdemServicoId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.TipoOrdemServicoId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.TipoOrdemServicoId);

            return source;
        }

        protected override IQueryable<TipoOrdemServico> MapperGetByFiltersToDomainFields(IQueryable<TipoOrdemServico> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new TipoOrdemServico
                {

                }).AsQueryable();
            }

            return result.Select(_ => (TipoOrdemServico)_).AsQueryable();

        }

        protected override TipoOrdemServico MapperGetOneToDomainFields(IQueryable<TipoOrdemServico> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new TipoOrdemServico
                {

                };
            }

            return source.SingleOrDefault();
        }

        protected override Expression<Func<TipoOrdemServico, object>>[] DataAgregation(Expression<Func<TipoOrdemServico, object>>[] includes, FilterBase filter)
        {
            return includes.Add(_ => _.Setor, _ => _.Prioridade);
        }

    }
}
