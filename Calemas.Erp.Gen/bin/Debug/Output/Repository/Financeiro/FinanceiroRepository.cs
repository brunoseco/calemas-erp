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
    public class FinanceiroRepository : Repository<Financeiro>, IFinanceiroRepository
    {
        public FinanceiroRepository(DbContextCore ctx) : base(ctx)
        {


        }

      
        public IQueryable<Financeiro> GetBySimplefilters(FinanceiroFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters);
            return querybase;
        }

        public async Task<Financeiro> GetById(FinanceiroFilter model)
        {
            var _financeiro = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.FinanceiroId == model.FinanceiroId));

            return _financeiro;
        }

		 public async Task<IEnumerable<dynamic>> GetDataItem(FinanceiroFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.FinanceiroId

            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(FinanceiroFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.FinanceiroId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(FinanceiroFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.FinanceiroId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<Financeiro> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<Financeiro> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.FinanceiroId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.FinanceiroId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.FinanceiroId);

            return source;
        }

        protected override IQueryable<Financeiro> MapperGetByFiltersToDomainFields(IQueryable<Financeiro> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new Financeiro
                {

                }).AsQueryable();
            }

            return result.Select(_ => (Financeiro)_).AsQueryable();

        }

        protected override Financeiro MapperGetOneToDomainFields(IQueryable<Financeiro> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new Financeiro
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<Financeiro, object>>[] DataAgregation(Expression<Func<Financeiro, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
