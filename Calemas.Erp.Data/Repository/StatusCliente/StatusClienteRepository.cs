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
    public class StatusClienteRepository : Repository<StatusCliente>, IStatusClienteRepository
    {
        public StatusClienteRepository(DbContextCore ctx) : base(ctx)
        {


        }


        public IQueryable<StatusCliente> GetBySimplefilters(StatusClienteFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
                                .WithBasicFilters(filters)
                                .WithCustomFilters(filters);
            return querybase;
        }

        public async Task<StatusCliente> GetById(StatusClienteFilter model)
        {
            var _statuscliente = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_ => _.StatusClienteId == model.StatusClienteId));

            return _statuscliente;
        }

        public async Task<IEnumerable<dynamic>> GetDataItem(StatusClienteFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusClienteId,
                Name = _.Nome

            }));

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(StatusClienteFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusClienteId,
                Name = _.Nome
            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(StatusClienteFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusClienteId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<StatusCliente> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<StatusCliente> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.StatusClienteId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.StatusClienteId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.StatusClienteId);

            return source;
        }

        protected override IQueryable<StatusCliente> MapperGetByFiltersToDomainFields(IQueryable<StatusCliente> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new StatusCliente
                {

                }).AsQueryable();
            }

            return result.Select(_ => (StatusCliente)_).AsQueryable();

        }

        protected override StatusCliente MapperGetOneToDomainFields(IQueryable<StatusCliente> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new StatusCliente
                {

                };
            }

            return source.SingleOrDefault();
        }

        protected override Expression<Func<StatusCliente, object>>[] DataAgregation(Expression<Func<StatusCliente, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
