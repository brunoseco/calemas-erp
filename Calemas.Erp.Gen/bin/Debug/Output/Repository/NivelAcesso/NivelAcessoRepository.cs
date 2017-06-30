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
    public class NivelAcessoRepository : Repository<NivelAcesso>, INivelAcessoRepository
    {
        public NivelAcessoRepository(DbContextCore ctx) : base(ctx)
        {


        }

      
        public IQueryable<NivelAcesso> GetBySimplefilters(NivelAcessoFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters);
            return querybase;
        }

        public async Task<NivelAcesso> GetById(NivelAcessoFilter model)
        {
            var _nivelacesso = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.NivelAcessoId == model.NivelAcessoId));

            return _nivelacesso;
        }

		 public async Task<IEnumerable<dynamic>> GetDataItem(NivelAcessoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.NivelAcessoId

            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(NivelAcessoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.NivelAcessoId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(NivelAcessoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.NivelAcessoId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<NivelAcesso> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<NivelAcesso> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.NivelAcessoId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.NivelAcessoId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.NivelAcessoId);

            return source;
        }

        protected override IQueryable<NivelAcesso> MapperGetByFiltersToDomainFields(IQueryable<NivelAcesso> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new NivelAcesso
                {

                }).AsQueryable();
            }

            return result.Select(_ => (NivelAcesso)_).AsQueryable();

        }

        protected override NivelAcesso MapperGetOneToDomainFields(IQueryable<NivelAcesso> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new NivelAcesso
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<NivelAcesso, object>>[] DataAgregation(Expression<Func<NivelAcesso, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
