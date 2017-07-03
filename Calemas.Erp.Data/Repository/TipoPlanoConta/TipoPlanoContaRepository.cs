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
    public class TipoPlanoContaRepository : Repository<TipoPlanoConta>, ITipoPlanoContaRepository
    {
        public TipoPlanoContaRepository(DbContextCore ctx) : base(ctx)
        {


        }

      
        public IQueryable<TipoPlanoConta> GetBySimplefilters(TipoPlanoContaFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters);
            return querybase;
        }

        public async Task<TipoPlanoConta> GetById(TipoPlanoContaFilter model)
        {
            var _tipoplanoconta = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.TipoPlanoContaId == model.TipoPlanoContaId));

            return _tipoplanoconta;
        }

		 public async Task<IEnumerable<dynamic>> GetDataItem(TipoPlanoContaFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TipoPlanoContaId,
                Name = _.Nome
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(TipoPlanoContaFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TipoPlanoContaId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(TipoPlanoContaFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TipoPlanoContaId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<TipoPlanoConta> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<TipoPlanoConta> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.TipoPlanoContaId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.TipoPlanoContaId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.TipoPlanoContaId);

            return source;
        }

        protected override IQueryable<TipoPlanoConta> MapperGetByFiltersToDomainFields(IQueryable<TipoPlanoConta> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new TipoPlanoConta
                {

                }).AsQueryable();
            }

            return result.Select(_ => (TipoPlanoConta)_).AsQueryable();

        }

        protected override TipoPlanoConta MapperGetOneToDomainFields(IQueryable<TipoPlanoConta> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new TipoPlanoConta
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<TipoPlanoConta, object>>[] DataAgregation(Expression<Func<TipoPlanoConta, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
