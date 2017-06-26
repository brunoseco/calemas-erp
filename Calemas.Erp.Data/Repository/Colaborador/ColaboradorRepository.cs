using Common.Domain.Base;
using Common.Orm;
using Calemas.Erp.Data.Context;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using Calemas.Erp.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;

namespace Calemas.Erp.Data.Repository
{
    public class ColaboradorRepository : Repository<Colaborador>, IColaboradorRepository
    {
        public ColaboradorRepository(DbContextCore ctx) : base(ctx)
        {


        }


        public IQueryable<Colaborador> GetBySimplefilters(ColaboradorFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
                                .WithBasicFilters(filters)
                                .WithCustomFilters(filters);
            return querybase;
        }

        public async Task<Colaborador> GetById(ColaboradorFilter model)
        {
            var _colaborador = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_ => _.ColaboradorId == model.ColaboradorId));

            return _colaborador;
        }

        public async Task<IEnumerable<dynamic>> GetDataItem(ColaboradorFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.ColaboradorId

            }));

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(ColaboradorFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.ColaboradorId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(ColaboradorFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.ColaboradorId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<Colaborador> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<Colaborador> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.ColaboradorId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.ColaboradorId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.ColaboradorId);

            return source;
        }

        protected override IQueryable<Colaborador> MapperGetByFiltersToDomainFields(IQueryable<Colaborador> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new Colaborador
                {

                }).AsQueryable();
            }

            return result.Select(_ => (Colaborador)_).AsQueryable();

        }

        protected override Colaborador MapperGetOneToDomainFields(IQueryable<Colaborador> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new Colaborador
                {

                };
            }

            return source.SingleOrDefault();
        }

        protected override Expression<Func<Colaborador, object>>[] DataAgregation(Expression<Func<Colaborador, object>>[] includes, FilterBase filter)
        {
            return includes.Add(_ => _.Pessoa);
        }

    }
}
