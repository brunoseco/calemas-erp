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
    public class AgendaColaboradorRepository : Repository<AgendaColaborador>, IAgendaColaboradorRepository
    {
        public AgendaColaboradorRepository(DbContextCore ctx) : base(ctx)
        {


        }

      
        public IQueryable<AgendaColaborador> GetBySimplefilters(AgendaColaboradorFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters);
            return querybase;
        }

        public async Task<AgendaColaborador> GetById(AgendaColaboradorFilter model)
        {
            var _agendacolaborador = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.AgendaId == model.AgendaId).Where(_=>_.ColaboradorId == model.ColaboradorId));

            return _agendacolaborador;
        }

		 public async Task<IEnumerable<dynamic>> GetDataItem(AgendaColaboradorFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.AgendaId

            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(AgendaColaboradorFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.AgendaId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(AgendaColaboradorFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.AgendaId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<AgendaColaborador> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<AgendaColaborador> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.AgendaColaboradorId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.AgendaColaboradorId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.AgendaColaboradorId);

            return source;
        }

        protected override IQueryable<AgendaColaborador> MapperGetByFiltersToDomainFields(IQueryable<AgendaColaborador> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new AgendaColaborador
                {

                }).AsQueryable();
            }

            return result.Select(_ => (AgendaColaborador)_).AsQueryable();

        }

        protected override AgendaColaborador MapperGetOneToDomainFields(IQueryable<AgendaColaborador> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new AgendaColaborador
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<AgendaColaborador, object>>[] DataAgregation(Expression<Func<AgendaColaborador, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
