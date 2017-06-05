using Common.Domain.Base;
using Common.Orm;
using Calemas.Erp.Data.Context;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using Calemas.Erp.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public class BancoRepository : Repository<Banco>, IBancoRepository
    {
        public BancoRepository(DbContextCalemas.Erp ctx) : base(ctx)
        {


        }

      
        public IQueryable<Banco> GetBySimplefilters(BancoFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters);
            return querybase;
        }

        public Banco GetById(BancoFilter model)
        {
            var _banco = this.GetAll(this.DataAgregation(model))
               .Where(_=>_.BancoId == model.BancoId)
               .SingleOrDefault();

            return _banco;
        }

		 public IEnumerable<dynamic> GetDataItem(BancoFilter filters)
        {
            var querybase = this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.BancoId

            }).ToList(); 

            return querybase;
        }

        public IEnumerable<dynamic> GetDataListCustom(BancoFilter filters)
        {
            var querybase = this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.BancoId,

            }).ToList();

            return querybase;
        }

        public dynamic GetDataCustom(BancoFilter filters)
        {
            var querybase = this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.BancoId,

            }).SingleOrDefault();

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<Banco> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                }).SingleOrDefault();
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<Banco> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.BancoId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.BancoId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.BancoId);

            return source;
        }

        protected override IQueryable<Banco> MapperGetByFiltersToDomainFields(IQueryable<Banco> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new Banco
                {

                }).AsQueryable();
            }

            return result.Select(_ => (Banco)_).AsQueryable();

        }

        protected override Banco MapperGetOneToDomainFields(IQueryable<Banco> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new Banco
                {

                };
            }

            return source.SingleOrDefault();
        }

    }
}
