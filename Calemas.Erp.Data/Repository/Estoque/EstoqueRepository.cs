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
    public class EstoqueRepository : Repository<Estoque>, IEstoqueRepository
    {
        public EstoqueRepository(DbContextCore ctx) : base(ctx)
        {


        }

      
        public IQueryable<Estoque> GetBySimplefilters(EstoqueFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters);
            return querybase;
        }

        public async Task<Estoque> GetById(EstoqueFilter model)
        {
            var _estoque = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.EstoqueId == model.EstoqueId));

            return _estoque;
        }

		 public async Task<IEnumerable<dynamic>> GetDataItem(EstoqueFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.EstoqueId,
                Name = _.Nome
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(EstoqueFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.EstoqueId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(EstoqueFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.EstoqueId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<Estoque> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<Estoque> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.EstoqueId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.EstoqueId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.EstoqueId);

            return source;
        }

        protected override IQueryable<Estoque> MapperGetByFiltersToDomainFields(IQueryable<Estoque> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new Estoque
                {

                }).AsQueryable();
            }

            return result.Select(_ => (Estoque)_).AsQueryable();

        }

        protected override Estoque MapperGetOneToDomainFields(IQueryable<Estoque> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new Estoque
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<Estoque, object>>[] DataAgregation(Expression<Func<Estoque, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
