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
    public class CategoriaEstoqueRepository : Repository<CategoriaEstoque>, ICategoriaEstoqueRepository
    {
        public CategoriaEstoqueRepository(DbContextCore ctx) : base(ctx)
        {


        }

      
        public IQueryable<CategoriaEstoque> GetBySimplefilters(CategoriaEstoqueFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters);
            return querybase;
        }

        public async Task<CategoriaEstoque> GetById(CategoriaEstoqueFilter model)
        {
            var _categoriaestoque = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.CategoriaEstoqueId == model.CategoriaEstoqueId));

            return _categoriaestoque;
        }

		 public async Task<IEnumerable<dynamic>> GetDataItem(CategoriaEstoqueFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.CategoriaEstoqueId

            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(CategoriaEstoqueFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.CategoriaEstoqueId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(CategoriaEstoqueFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.CategoriaEstoqueId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<CategoriaEstoque> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<CategoriaEstoque> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.CategoriaEstoqueId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.CategoriaEstoqueId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.CategoriaEstoqueId);

            return source;
        }

        protected override IQueryable<CategoriaEstoque> MapperGetByFiltersToDomainFields(IQueryable<CategoriaEstoque> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new CategoriaEstoque
                {

                }).AsQueryable();
            }

            return result.Select(_ => (CategoriaEstoque)_).AsQueryable();

        }

        protected override CategoriaEstoque MapperGetOneToDomainFields(IQueryable<CategoriaEstoque> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new CategoriaEstoque
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<CategoriaEstoque, object>>[] DataAgregation(Expression<Func<CategoriaEstoque, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
