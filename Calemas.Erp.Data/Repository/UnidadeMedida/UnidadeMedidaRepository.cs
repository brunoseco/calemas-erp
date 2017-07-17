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
    public class UnidadeMedidaRepository : Repository<UnidadeMedida>, IUnidadeMedidaRepository
    {
        public UnidadeMedidaRepository(DbContextCore ctx) : base(ctx)
        {


        }

      
        public IQueryable<UnidadeMedida> GetBySimplefilters(UnidadeMedidaFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters);
            return querybase;
        }

        public async Task<UnidadeMedida> GetById(UnidadeMedidaFilter model)
        {
            var _unidademedida = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.UnidadeMedidaId == model.UnidadeMedidaId));

            return _unidademedida;
        }

		 public async Task<IEnumerable<dynamic>> GetDataItem(UnidadeMedidaFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.UnidadeMedidaId,
                Name = _.Nome
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(UnidadeMedidaFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.UnidadeMedidaId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(UnidadeMedidaFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.UnidadeMedidaId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<UnidadeMedida> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<UnidadeMedida> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.UnidadeMedidaId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.UnidadeMedidaId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.UnidadeMedidaId);

            return source;
        }

        protected override IQueryable<UnidadeMedida> MapperGetByFiltersToDomainFields(IQueryable<UnidadeMedida> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new UnidadeMedida
                {

                }).AsQueryable();
            }

            return result.Select(_ => (UnidadeMedida)_).AsQueryable();

        }

        protected override UnidadeMedida MapperGetOneToDomainFields(IQueryable<UnidadeMedida> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new UnidadeMedida
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<UnidadeMedida, object>>[] DataAgregation(Expression<Func<UnidadeMedida, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
