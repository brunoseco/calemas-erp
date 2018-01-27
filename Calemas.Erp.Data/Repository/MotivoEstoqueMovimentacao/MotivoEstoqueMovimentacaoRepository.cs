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
    public class MotivoEstoqueMovimentacaoRepository : Repository<MotivoEstoqueMovimentacao>, IMotivoEstoqueMovimentacaoRepository
    {
        private CurrentUser _user;
        public MotivoEstoqueMovimentacaoRepository(DbContextCore ctx, CurrentUser user) : base(ctx)
        {
			this._user = user;
        }

      
        public IQueryable<MotivoEstoqueMovimentacao> GetBySimplefilters(MotivoEstoqueMovimentacaoFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
                                .WithBasicFilters(filters)
                                .WithCustomFilters(filters)
                                .OrderByDomain(filters);
            return querybase;
        }

        public async Task<MotivoEstoqueMovimentacao> GetById(MotivoEstoqueMovimentacaoFilter model)
        {
            var _motivoestoquemovimentacao = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.MotivoEstoqueMovimentacaoId == model.MotivoEstoqueMovimentacaoId));

            return _motivoestoquemovimentacao;
        }

		public async Task<IEnumerable<dynamic>> GetDataItem(MotivoEstoqueMovimentacaoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.MotivoEstoqueMovimentacaoId,
				Name = _.Nome
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(MotivoEstoqueMovimentacaoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.MotivoEstoqueMovimentacaoId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(MotivoEstoqueMovimentacaoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.MotivoEstoqueMovimentacaoId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<MotivoEstoqueMovimentacao> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<MotivoEstoqueMovimentacao> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.MotivoEstoqueMovimentacaoId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.MotivoEstoqueMovimentacaoId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.MotivoEstoqueMovimentacaoId);

            return source;
        }

        protected override IQueryable<MotivoEstoqueMovimentacao> MapperGetByFiltersToDomainFields(IQueryable<MotivoEstoqueMovimentacao> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new MotivoEstoqueMovimentacao
                {

                }).AsQueryable();
            }

            return result.Select(_ => (MotivoEstoqueMovimentacao)_).AsQueryable();

        }

        protected override MotivoEstoqueMovimentacao MapperGetOneToDomainFields(IQueryable<MotivoEstoqueMovimentacao> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new MotivoEstoqueMovimentacao
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<MotivoEstoqueMovimentacao, object>>[] DataAgregation(Expression<Func<MotivoEstoqueMovimentacao, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
