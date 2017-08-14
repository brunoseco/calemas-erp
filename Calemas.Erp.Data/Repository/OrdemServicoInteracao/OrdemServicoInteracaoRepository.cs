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
    public class OrdemServicoInteracaoRepository : Repository<OrdemServicoInteracao>, IOrdemServicoInteracaoRepository
    {
        public OrdemServicoInteracaoRepository(DbContextCore ctx) : base(ctx)
        {


        }

      
        public IQueryable<OrdemServicoInteracao> GetBySimplefilters(OrdemServicoInteracaoFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters);
            return querybase;
        }

        public async Task<OrdemServicoInteracao> GetById(OrdemServicoInteracaoFilter model)
        {
            var _ordemservicointeracao = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.OrdemServicoInteracaoId == model.OrdemServicoInteracaoId));

            return _ordemservicointeracao;
        }

		 public async Task<IEnumerable<dynamic>> GetDataItem(OrdemServicoInteracaoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.OrdemServicoInteracaoId

            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(OrdemServicoInteracaoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.OrdemServicoInteracaoId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(OrdemServicoInteracaoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.OrdemServicoInteracaoId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<OrdemServicoInteracao> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<OrdemServicoInteracao> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.OrdemServicoInteracaoId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.OrdemServicoInteracaoId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.OrdemServicoInteracaoId);

            return source;
        }

        protected override IQueryable<OrdemServicoInteracao> MapperGetByFiltersToDomainFields(IQueryable<OrdemServicoInteracao> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new OrdemServicoInteracao
                {

                }).AsQueryable();
            }

            return result.Select(_ => (OrdemServicoInteracao)_).AsQueryable();

        }

        protected override OrdemServicoInteracao MapperGetOneToDomainFields(IQueryable<OrdemServicoInteracao> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new OrdemServicoInteracao
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<OrdemServicoInteracao, object>>[] DataAgregation(Expression<Func<OrdemServicoInteracao, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
