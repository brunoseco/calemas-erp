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
    public class SetorRepository : Repository<Setor>, ISetorRepository
    {
        public SetorRepository(DbContextCore ctx) : base(ctx)
        {


        }

      
        public IQueryable<Setor> GetBySimplefilters(SetorFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters);
            return querybase;
        }

        public async Task<Setor> GetById(SetorFilter model)
        {
            var _setor = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.SetorId == model.SetorId));

            return _setor;
        }

		 public async Task<IEnumerable<dynamic>> GetDataItem(SetorFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SetorId

            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(SetorFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SetorId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(SetorFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SetorId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<Setor> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<Setor> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.SetorId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.SetorId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.SetorId);

            return source;
        }

        protected override IQueryable<Setor> MapperGetByFiltersToDomainFields(IQueryable<Setor> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new Setor
                {

                }).AsQueryable();
            }

            return result.Select(_ => (Setor)_).AsQueryable();

        }

        protected override Setor MapperGetOneToDomainFields(IQueryable<Setor> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new Setor
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<Setor, object>>[] DataAgregation(Expression<Func<Setor, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
