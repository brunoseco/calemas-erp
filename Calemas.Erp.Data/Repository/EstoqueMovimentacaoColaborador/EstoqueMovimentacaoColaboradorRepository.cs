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
    public class EstoqueMovimentacaoColaboradorRepository : Repository<EstoqueMovimentacaoColaborador>, IEstoqueMovimentacaoColaboradorRepository
    {
        private CurrentUser _user;
        public EstoqueMovimentacaoColaboradorRepository(DbContextCore ctx, CurrentUser user) : base(ctx)
        {
            this._user = user;
        }


        public IQueryable<EstoqueMovimentacaoColaborador> GetBySimplefilters(EstoqueMovimentacaoColaboradorFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
                                .WithBasicFilters(filters)
                                .WithCustomFilters(filters)
                                .OrderByDomain(filters);
            return querybase;
        }

        public async Task<EstoqueMovimentacaoColaborador> GetById(EstoqueMovimentacaoColaboradorFilter model)
        {
            var _estoquemovimentacaocolaborador = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_ => _.EstoqueMovimentacaoColaboradorId == model.EstoqueMovimentacaoColaboradorId));

            return _estoquemovimentacaocolaborador;
        }

        public async Task<IEnumerable<dynamic>> GetDataItem(EstoqueMovimentacaoColaboradorFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.EstoqueMovimentacaoColaboradorId,
                Name = _.Entrada
            }));

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(EstoqueMovimentacaoColaboradorFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).GroupBy(_ => _.Colaborador).Select(_ => new
            {
                Nome = _.Key.Pessoa.Nome,
                Quantidade = _.Sum(__ => __.Quantidade * (__.Entrada ? 1 : -1))
            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(EstoqueMovimentacaoColaboradorFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.EstoqueMovimentacaoColaboradorId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<EstoqueMovimentacaoColaborador> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<EstoqueMovimentacaoColaborador> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.EstoqueMovimentacaoColaboradorId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.EstoqueMovimentacaoColaboradorId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.EstoqueMovimentacaoColaboradorId);

            return source;
        }

        protected override IQueryable<EstoqueMovimentacaoColaborador> MapperGetByFiltersToDomainFields(IQueryable<EstoqueMovimentacaoColaborador> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new EstoqueMovimentacaoColaborador
                {

                }).AsQueryable();
            }

            return result.Select(_ => (EstoqueMovimentacaoColaborador)_).AsQueryable();

        }

        protected override EstoqueMovimentacaoColaborador MapperGetOneToDomainFields(IQueryable<EstoqueMovimentacaoColaborador> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new EstoqueMovimentacaoColaborador
                {

                };
            }

            return source.SingleOrDefault();
        }

        protected override Expression<Func<EstoqueMovimentacaoColaborador, object>>[] DataAgregation(Expression<Func<EstoqueMovimentacaoColaborador, object>>[] includes, FilterBase filter)
        {
            return includes.Add(_ => _.Colaborador.Pessoa);
        }

    }
}
