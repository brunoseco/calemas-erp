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
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(DbContextCore ctx) : base(ctx)
        {


        }

      
        public IQueryable<Endereco> GetBySimplefilters(EnderecoFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters);
            return querybase;
        }

        public async Task<Endereco> GetById(EnderecoFilter model)
        {
            var _endereco = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.EnderecoId == model.EnderecoId));

            return _endereco;
        }

		 public async Task<IEnumerable<dynamic>> GetDataItem(EnderecoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.EnderecoId

            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(EnderecoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.EnderecoId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(EnderecoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.EnderecoId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<Endereco> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<Endereco> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.EnderecoId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.EnderecoId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.EnderecoId);

            return source;
        }

        protected override IQueryable<Endereco> MapperGetByFiltersToDomainFields(IQueryable<Endereco> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new Endereco
                {

                }).AsQueryable();
            }

            return result.Select(_ => (Endereco)_).AsQueryable();

        }

        protected override Endereco MapperGetOneToDomainFields(IQueryable<Endereco> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new Endereco
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<Endereco, object>>[] DataAgregation(Expression<Func<Endereco, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
