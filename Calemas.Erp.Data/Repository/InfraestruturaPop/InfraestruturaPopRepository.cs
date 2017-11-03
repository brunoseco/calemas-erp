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
using Common.Domain.Model;

namespace Calemas.Erp.Data.Repository
{
    public class InfraestruturaPopRepository : Repository<InfraestruturaPop>, IInfraestruturaPopRepository
    {
        private CurrentUser _user;
        public InfraestruturaPopRepository(DbContextCore ctx, CurrentUser user) : base(ctx)
        {
			this._user = user;
        }

      
        public IQueryable<InfraestruturaPop> GetBySimplefilters(InfraestruturaPopFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters);
            return querybase;
        }

        public async Task<InfraestruturaPop> GetById(InfraestruturaPopFilter model)
        {
            var _infraestruturapop = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.InfraestruturaPopId == model.InfraestruturaPopId));

            return _infraestruturapop;
        }

		 public async Task<IEnumerable<dynamic>> GetDataItem(InfraestruturaPopFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.InfraestruturaPopId,
                Name = _.Nome

            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(InfraestruturaPopFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.InfraestruturaPopId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(InfraestruturaPopFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.InfraestruturaPopId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<InfraestruturaPop> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<InfraestruturaPop> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.InfraestruturaPopId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.InfraestruturaPopId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.InfraestruturaPopId);

            return source;
        }

        protected override IQueryable<InfraestruturaPop> MapperGetByFiltersToDomainFields(IQueryable<InfraestruturaPop> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new InfraestruturaPop
                {

                }).AsQueryable();
            }

            return result.Select(_ => (InfraestruturaPop)_).AsQueryable();

        }

        protected override InfraestruturaPop MapperGetOneToDomainFields(IQueryable<InfraestruturaPop> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new InfraestruturaPop
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<InfraestruturaPop, object>>[] DataAgregation(Expression<Func<InfraestruturaPop, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
