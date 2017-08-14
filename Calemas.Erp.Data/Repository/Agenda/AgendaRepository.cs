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
    public class AgendaRepository : Repository<Agenda>, IAgendaRepository
    {
        public AgendaRepository(DbContextCore ctx) : base(ctx)
        {


        }

      
        public IQueryable<Agenda> GetBySimplefilters(AgendaFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters);
            return querybase;
        }

        public async Task<Agenda> GetById(AgendaFilter model)
        {
            var _agenda = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.AgendaId == model.AgendaId));

            return _agenda;
        }

		 public async Task<IEnumerable<dynamic>> GetDataItem(AgendaFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.AgendaId

            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(AgendaFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.AgendaId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(AgendaFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.AgendaId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<Agenda> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<Agenda> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.AgendaId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.AgendaId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.AgendaId);

            return source;
        }

        protected override IQueryable<Agenda> MapperGetByFiltersToDomainFields(IQueryable<Agenda> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new Agenda
                {

                }).AsQueryable();
            }

            return result.Select(_ => (Agenda)_).AsQueryable();

        }

        protected override Agenda MapperGetOneToDomainFields(IQueryable<Agenda> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new Agenda
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<Agenda, object>>[] DataAgregation(Expression<Func<Agenda, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
