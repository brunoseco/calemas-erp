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
    public class StatusSolicitacaoEstoqueMovimentacaoRepository : Repository<StatusSolicitacaoEstoqueMovimentacao>, IStatusSolicitacaoEstoqueMovimentacaoRepository
    {
        private CurrentUser _user;
        public StatusSolicitacaoEstoqueMovimentacaoRepository(DbContextCore ctx, CurrentUser user) : base(ctx)
        {
            this._user = user;
        }


        public IQueryable<StatusSolicitacaoEstoqueMovimentacao> GetBySimplefilters(StatusSolicitacaoEstoqueMovimentacaoFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
                                .WithBasicFilters(filters)
                                .WithCustomFilters(filters);
            return querybase;
        }

        public async Task<StatusSolicitacaoEstoqueMovimentacao> GetById(StatusSolicitacaoEstoqueMovimentacaoFilter model)
        {
            var _statussolicitacaoestoquemovimentacao = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_ => _.StatusSolicitacaoEstoqueMovimentacaoId == model.StatusSolicitacaoEstoqueMovimentacaoId));

            return _statussolicitacaoestoquemovimentacao;
        }

        public async Task<IEnumerable<dynamic>> GetDataItem(StatusSolicitacaoEstoqueMovimentacaoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusSolicitacaoEstoqueMovimentacaoId,
                Name = _.Nome
            }));

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(StatusSolicitacaoEstoqueMovimentacaoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusSolicitacaoEstoqueMovimentacaoId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(StatusSolicitacaoEstoqueMovimentacaoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusSolicitacaoEstoqueMovimentacaoId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<StatusSolicitacaoEstoqueMovimentacao> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<StatusSolicitacaoEstoqueMovimentacao> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.StatusSolicitacaoEstoqueMovimentacaoId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.StatusSolicitacaoEstoqueMovimentacaoId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.StatusSolicitacaoEstoqueMovimentacaoId);

            return source;
        }

        protected override IQueryable<StatusSolicitacaoEstoqueMovimentacao> MapperGetByFiltersToDomainFields(IQueryable<StatusSolicitacaoEstoqueMovimentacao> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new StatusSolicitacaoEstoqueMovimentacao
                {

                }).AsQueryable();
            }

            return result.Select(_ => (StatusSolicitacaoEstoqueMovimentacao)_).AsQueryable();

        }

        protected override StatusSolicitacaoEstoqueMovimentacao MapperGetOneToDomainFields(IQueryable<StatusSolicitacaoEstoqueMovimentacao> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new StatusSolicitacaoEstoqueMovimentacao
                {

                };
            }

            return source.SingleOrDefault();
        }

        protected override Expression<Func<StatusSolicitacaoEstoqueMovimentacao, object>>[] DataAgregation(Expression<Func<StatusSolicitacaoEstoqueMovimentacao, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
