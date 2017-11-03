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
    public class InfraestruturaSiteRepository : Repository<InfraestruturaSite>, IInfraestruturaSiteRepository
    {
        private CurrentUser _user;
        public InfraestruturaSiteRepository(DbContextCore ctx, CurrentUser user) : base(ctx)
        {
			this._user = user;
        }

      
        public IQueryable<InfraestruturaSite> GetBySimplefilters(InfraestruturaSiteFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters);
            return querybase;
        }

        public async Task<InfraestruturaSite> GetById(InfraestruturaSiteFilter model)
        {
            var _infraestruturasite = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.InfraestruturaSiteId == model.InfraestruturaSiteId));

            return _infraestruturasite;
        }

		 public async Task<IEnumerable<dynamic>> GetDataItem(InfraestruturaSiteFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.InfraestruturaSiteId,
                Name = _.Nome
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(InfraestruturaSiteFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.InfraestruturaSiteId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(InfraestruturaSiteFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.InfraestruturaSiteId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<InfraestruturaSite> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<InfraestruturaSite> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.InfraestruturaSiteId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.InfraestruturaSiteId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.InfraestruturaSiteId);

            return source;
        }

        protected override IQueryable<InfraestruturaSite> MapperGetByFiltersToDomainFields(IQueryable<InfraestruturaSite> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new InfraestruturaSite
                {

                }).AsQueryable();
            }

            return result.Select(_ => (InfraestruturaSite)_).AsQueryable();

        }

        protected override InfraestruturaSite MapperGetOneToDomainFields(IQueryable<InfraestruturaSite> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new InfraestruturaSite
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<InfraestruturaSite, object>>[] DataAgregation(Expression<Func<InfraestruturaSite, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
