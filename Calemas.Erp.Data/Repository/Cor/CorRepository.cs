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
    public class CorRepository : Repository<Cor>, ICorRepository
    {
        public CorRepository(DbContextCore ctx) : base(ctx)
        {


        }

      
        public IQueryable<Cor> GetBySimplefilters(CorFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters);
            return querybase;
        }

        public async Task<Cor> GetById(CorFilter model)
        {
            var _cor = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.CorId == model.CorId));

            return _cor;
        }

		 public async Task<IEnumerable<dynamic>> GetDataItem(CorFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.CorId,
                Name = _.Nome
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(CorFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.CorId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(CorFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.CorId,
                
            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<Cor> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<Cor> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.CorId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.CorId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.CorId);

            return source;
        }

        protected override IQueryable<Cor> MapperGetByFiltersToDomainFields(IQueryable<Cor> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new Cor
                {

                }).AsQueryable();
            }

            return result.Select(_ => (Cor)_).AsQueryable();

        }

        protected override Cor MapperGetOneToDomainFields(IQueryable<Cor> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new Cor
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<Cor, object>>[] DataAgregation(Expression<Func<Cor, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
