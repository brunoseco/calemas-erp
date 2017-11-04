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
    public class SolicitacaoEstoqueMovimentacaoRepository : Repository<SolicitacaoEstoqueMovimentacao>, ISolicitacaoEstoqueMovimentacaoRepository
    {
        private CurrentUser _user;
        public SolicitacaoEstoqueMovimentacaoRepository(DbContextCore ctx, CurrentUser user) : base(ctx)
        {
            this._user = user;
        }


        public IQueryable<SolicitacaoEstoqueMovimentacao> GetBySimplefilters(SolicitacaoEstoqueMovimentacaoFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
                                .WithBasicFilters(filters)
                                .WithCustomFilters(filters);
            return querybase;
        }

        public async Task<SolicitacaoEstoqueMovimentacao> GetById(SolicitacaoEstoqueMovimentacaoFilter model)
        {
            var _solicitacaoestoquemovimentacao = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_ => _.SolicitacaoEstoqueMovimentacaoId == model.SolicitacaoEstoqueMovimentacaoId));

            return _solicitacaoestoquemovimentacao;
        }

        public async Task<IEnumerable<dynamic>> GetDataItem(SolicitacaoEstoqueMovimentacaoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SolicitacaoEstoqueMovimentacaoId

            }));

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(SolicitacaoEstoqueMovimentacaoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SolicitacaoEstoqueMovimentacaoId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(SolicitacaoEstoqueMovimentacaoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SolicitacaoEstoqueMovimentacaoId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<SolicitacaoEstoqueMovimentacao> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<SolicitacaoEstoqueMovimentacao> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.SolicitacaoEstoqueMovimentacaoId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.SolicitacaoEstoqueMovimentacaoId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.SolicitacaoEstoqueMovimentacaoId);

            return source;
        }

        protected override IQueryable<SolicitacaoEstoqueMovimentacao> MapperGetByFiltersToDomainFields(IQueryable<SolicitacaoEstoqueMovimentacao> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new SolicitacaoEstoqueMovimentacao
                {

                }).AsQueryable();
            }

            return result.Select(_ => (SolicitacaoEstoqueMovimentacao)_).AsQueryable();

        }

        protected override SolicitacaoEstoqueMovimentacao MapperGetOneToDomainFields(IQueryable<SolicitacaoEstoqueMovimentacao> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new SolicitacaoEstoqueMovimentacao
                {

                };
            }

            return source.SingleOrDefault();
        }

        protected override Expression<Func<SolicitacaoEstoqueMovimentacao, object>>[] DataAgregation(Expression<Func<SolicitacaoEstoqueMovimentacao, object>>[] includes, FilterBase filter)
        {
            return includes.Add(_ => _.Estoque);
        }

    }
}
