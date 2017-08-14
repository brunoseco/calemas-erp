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
    public class StatusOrdemServicoRepository : Repository<StatusOrdemServico>, IStatusOrdemServicoRepository
    {
        public StatusOrdemServicoRepository(DbContextCore ctx) : base(ctx)
        {


        }

      
        public IQueryable<StatusOrdemServico> GetBySimplefilters(StatusOrdemServicoFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters);
            return querybase;
        }

        public async Task<StatusOrdemServico> GetById(StatusOrdemServicoFilter model)
        {
            var _statusordemservico = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.StatusOrdemServicoId == model.StatusOrdemServicoId));

            return _statusordemservico;
        }

		 public async Task<IEnumerable<dynamic>> GetDataItem(StatusOrdemServicoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusOrdemServicoId

            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(StatusOrdemServicoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusOrdemServicoId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(StatusOrdemServicoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusOrdemServicoId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<StatusOrdemServico> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<StatusOrdemServico> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.StatusOrdemServicoId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.StatusOrdemServicoId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.StatusOrdemServicoId);

            return source;
        }

        protected override IQueryable<StatusOrdemServico> MapperGetByFiltersToDomainFields(IQueryable<StatusOrdemServico> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new StatusOrdemServico
                {

                }).AsQueryable();
            }

            return result.Select(_ => (StatusOrdemServico)_).AsQueryable();

        }

        protected override StatusOrdemServico MapperGetOneToDomainFields(IQueryable<StatusOrdemServico> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new StatusOrdemServico
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<StatusOrdemServico, object>>[] DataAgregation(Expression<Func<StatusOrdemServico, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
