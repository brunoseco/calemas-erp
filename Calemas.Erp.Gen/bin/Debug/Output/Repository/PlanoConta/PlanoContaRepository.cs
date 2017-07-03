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
    public class PlanoContaRepository : Repository<PlanoConta>, IPlanoContaRepository
    {
        public PlanoContaRepository(DbContextCore ctx) : base(ctx)
        {


        }

      
        public IQueryable<PlanoConta> GetBySimplefilters(PlanoContaFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters);
            return querybase;
        }

        public async Task<PlanoConta> GetById(PlanoContaFilter model)
        {
            var _planoconta = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.PlanoContaId == model.PlanoContaId));

            return _planoconta;
        }

		 public async Task<IEnumerable<dynamic>> GetDataItem(PlanoContaFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.PlanoContaId

            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(PlanoContaFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.PlanoContaId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(PlanoContaFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.PlanoContaId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<PlanoConta> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<PlanoConta> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.PlanoContaId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.PlanoContaId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.PlanoContaId);

            return source;
        }

        protected override IQueryable<PlanoConta> MapperGetByFiltersToDomainFields(IQueryable<PlanoConta> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new PlanoConta
                {

                }).AsQueryable();
            }

            return result.Select(_ => (PlanoConta)_).AsQueryable();

        }

        protected override PlanoConta MapperGetOneToDomainFields(IQueryable<PlanoConta> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new PlanoConta
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<PlanoConta, object>>[] DataAgregation(Expression<Func<PlanoConta, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
