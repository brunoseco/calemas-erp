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
    public class PrioridadeRepository : Repository<Prioridade>, IPrioridadeRepository
    {
        public PrioridadeRepository(DbContextCore ctx) : base(ctx)
        {


        }

      
        public IQueryable<Prioridade> GetBySimplefilters(PrioridadeFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters);
            return querybase;
        }

        public async Task<Prioridade> GetById(PrioridadeFilter model)
        {
            var _prioridade = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.PrioridadeId == model.PrioridadeId));

            return _prioridade;
        }

		 public async Task<IEnumerable<dynamic>> GetDataItem(PrioridadeFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.PrioridadeId,
                Name = _.Nome
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(PrioridadeFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.PrioridadeId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(PrioridadeFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.PrioridadeId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<Prioridade> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<Prioridade> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.PrioridadeId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.PrioridadeId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.PrioridadeId);

            return source;
        }

        protected override IQueryable<Prioridade> MapperGetByFiltersToDomainFields(IQueryable<Prioridade> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new Prioridade
                {

                }).AsQueryable();
            }

            return result.Select(_ => (Prioridade)_).AsQueryable();

        }

        protected override Prioridade MapperGetOneToDomainFields(IQueryable<Prioridade> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new Prioridade
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<Prioridade, object>>[] DataAgregation(Expression<Func<Prioridade, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
