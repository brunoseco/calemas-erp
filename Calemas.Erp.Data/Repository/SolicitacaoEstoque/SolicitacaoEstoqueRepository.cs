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
    public class SolicitacaoEstoqueRepository : Repository<SolicitacaoEstoque>, ISolicitacaoEstoqueRepository
    {
        private CurrentUser _user;
        public SolicitacaoEstoqueRepository(DbContextCore ctx, CurrentUser user) : base(ctx)
        {
            this._user = user;
        }


        public IQueryable<SolicitacaoEstoque> GetBySimplefilters(SolicitacaoEstoqueFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
                                .WithBasicFilters(filters)
                                .WithCustomFilters(filters);
            return querybase;
        }

        public async Task<SolicitacaoEstoque> GetById(SolicitacaoEstoqueFilter model)
        {
            var _solicitacaoestoque = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_ => _.SolicitacaoEstoqueId == model.SolicitacaoEstoqueId));

            return _solicitacaoestoque;
        }

        public async Task<IEnumerable<dynamic>> GetDataItem(SolicitacaoEstoqueFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SolicitacaoEstoqueId

            }));

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(SolicitacaoEstoqueFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SolicitacaoEstoqueId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(SolicitacaoEstoqueFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SolicitacaoEstoqueId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<SolicitacaoEstoque> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<SolicitacaoEstoque> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.SolicitacaoEstoqueId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.SolicitacaoEstoqueId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.SolicitacaoEstoqueId);

            return source;
        }

        protected override IQueryable<SolicitacaoEstoque> MapperGetByFiltersToDomainFields(IQueryable<SolicitacaoEstoque> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new SolicitacaoEstoque
                {

                }).AsQueryable();
            }

            return result.Select(_ => (SolicitacaoEstoque)_).AsQueryable();

        }

        protected override SolicitacaoEstoque MapperGetOneToDomainFields(IQueryable<SolicitacaoEstoque> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new SolicitacaoEstoque
                {

                };
            }

            return source.SingleOrDefault();
        }

        protected override Expression<Func<SolicitacaoEstoque, object>>[] DataAgregation(Expression<Func<SolicitacaoEstoque, object>>[] includes, FilterBase filter)
        {
            return includes.Add(_ => _.Solicitante.Pessoa, _ => _.StatusSolicitacaoEstoqueMovimentacao);
        }

    }
}
