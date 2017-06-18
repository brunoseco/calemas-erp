using Common.Domain.Base;
using Common.Orm;
using Calemas.Erp.Data.Context;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using Calemas.Erp.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Data.Repository
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(DbContextCore ctx) : base(ctx)
        {


        }

      
        public IQueryable<Pessoa> GetBySimplefilters(PessoaFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters);
            return querybase;
        }

        public async Task<Pessoa> GetById(PessoaFilter model)
        {
            var _pessoa = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.PessoaId == model.PessoaId));

            return _pessoa;
        }

		 public async Task<IEnumerable<dynamic>> GetDataItem(PessoaFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.PessoaId

            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(PessoaFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.PessoaId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(PessoaFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.PessoaId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<Pessoa> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<Pessoa> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.PessoaId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.PessoaId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.PessoaId);

            return source;
        }

        protected override IQueryable<Pessoa> MapperGetByFiltersToDomainFields(IQueryable<Pessoa> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new Pessoa
                {

                }).AsQueryable();
            }

            return result.Select(_ => (Pessoa)_).AsQueryable();

        }

        protected override Pessoa MapperGetOneToDomainFields(IQueryable<Pessoa> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new Pessoa
                {

                };
            }

            return source.SingleOrDefault();
        }

    }
}
