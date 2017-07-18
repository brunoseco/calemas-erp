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
    public class EstoqueMovimentacaoRepository : Repository<EstoqueMovimentacao>, IEstoqueMovimentacaoRepository
    {
        public EstoqueMovimentacaoRepository(DbContextCore ctx) : base(ctx)
        {


        }


        public IQueryable<EstoqueMovimentacao> GetBySimplefilters(EstoqueMovimentacaoFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
                                .WithBasicFilters(filters)
                                .WithCustomFilters(filters);
            return querybase;
        }

        public async Task<EstoqueMovimentacao> GetById(EstoqueMovimentacaoFilter model)
        {
            var _estoquemovimentacao = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_ => _.EstoqueMovimentacaoId == model.EstoqueMovimentacaoId));

            return _estoquemovimentacao;
        }

        public async Task<IEnumerable<dynamic>> GetDataItem(EstoqueMovimentacaoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.EstoqueMovimentacaoId

            }));

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(EstoqueMovimentacaoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.EstoqueMovimentacaoId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(EstoqueMovimentacaoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.EstoqueMovimentacaoId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<EstoqueMovimentacao> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<EstoqueMovimentacao> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.EstoqueMovimentacaoId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.EstoqueMovimentacaoId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.EstoqueMovimentacaoId);

            return source;
        }

        protected override IQueryable<EstoqueMovimentacao> MapperGetByFiltersToDomainFields(IQueryable<EstoqueMovimentacao> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new EstoqueMovimentacao
                {

                }).AsQueryable();
            }

            return result.Select(_ => (EstoqueMovimentacao)_).AsQueryable();

        }

        protected override EstoqueMovimentacao MapperGetOneToDomainFields(IQueryable<EstoqueMovimentacao> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new EstoqueMovimentacao
                {

                };
            }

            return source.SingleOrDefault();
        }

        protected override Expression<Func<EstoqueMovimentacao, object>>[] DataAgregation(Expression<Func<EstoqueMovimentacao, object>>[] includes, FilterBase filter)
        {
            return includes.Add(_ => _.Colaborador.Pessoa);
        }

    }
}
