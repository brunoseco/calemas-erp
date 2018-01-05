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
    public class StatusPagamentoRepository : Repository<StatusPagamento>, IStatusPagamentoRepository
    {
        private CurrentUser _user;
        public StatusPagamentoRepository(DbContextCore ctx, CurrentUser user) : base(ctx)
        {
			this._user = user;
        }

      
        public IQueryable<StatusPagamento> GetBySimplefilters(StatusPagamentoFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters);
            return querybase;
        }

        public async Task<StatusPagamento> GetById(StatusPagamentoFilter model)
        {
            var _statuspagamento = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.StatusPagamentoId == model.StatusPagamentoId));

            return _statuspagamento;
        }

		 public async Task<IEnumerable<dynamic>> GetDataItem(StatusPagamentoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusPagamentoId,
                Name = _.Nome
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(StatusPagamentoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusPagamentoId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(StatusPagamentoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusPagamentoId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<StatusPagamento> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<StatusPagamento> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.StatusPagamentoId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.StatusPagamentoId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.StatusPagamentoId);

            return source;
        }

        protected override IQueryable<StatusPagamento> MapperGetByFiltersToDomainFields(IQueryable<StatusPagamento> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new StatusPagamento
                {

                }).AsQueryable();
            }

            return result.Select(_ => (StatusPagamento)_).AsQueryable();

        }

        protected override StatusPagamento MapperGetOneToDomainFields(IQueryable<StatusPagamento> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new StatusPagamento
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<StatusPagamento, object>>[] DataAgregation(Expression<Func<StatusPagamento, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
