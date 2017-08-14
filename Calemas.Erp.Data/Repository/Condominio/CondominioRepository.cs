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
    public class CondominioRepository : Repository<Condominio>, ICondominioRepository
    {
        public CondominioRepository(DbContextCore ctx) : base(ctx)
        {


        }

      
        public IQueryable<Condominio> GetBySimplefilters(CondominioFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters);
            return querybase;
        }

        public async Task<Condominio> GetById(CondominioFilter model)
        {
            var _condominio = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.CondominioId == model.CondominioId));

            return _condominio;
        }

		 public async Task<IEnumerable<dynamic>> GetDataItem(CondominioFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.CondominioId,
                Name = _.Nome
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(CondominioFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.CondominioId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(CondominioFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.CondominioId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<Condominio> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<Condominio> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.CondominioId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.CondominioId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.CondominioId);

            return source;
        }

        protected override IQueryable<Condominio> MapperGetByFiltersToDomainFields(IQueryable<Condominio> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new Condominio
                {

                }).AsQueryable();
            }

            return result.Select(_ => (Condominio)_).AsQueryable();

        }

        protected override Condominio MapperGetOneToDomainFields(IQueryable<Condominio> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new Condominio
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<Condominio, object>>[] DataAgregation(Expression<Func<Condominio, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
