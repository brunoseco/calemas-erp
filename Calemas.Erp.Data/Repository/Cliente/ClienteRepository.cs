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
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DbContextCore ctx) : base(ctx)
        {


        }


        public IQueryable<Cliente> GetBySimplefilters(ClienteFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
                                .WithBasicFilters(filters)
                                .WithCustomFilters(filters);
            return querybase;
        }

        public async Task<Cliente> GetById(ClienteFilter model)
        {
            var _cliente = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_ => _.ClienteId == model.ClienteId));

            return _cliente;
        }

        public async Task<IEnumerable<dynamic>> GetDataItem(ClienteFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.ClienteId,
                Name = _.Pessoa.Nome
            }));

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(ClienteFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.ClienteId,
                Name = _.Pessoa.Nome
            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(ClienteFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.ClienteId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<Cliente> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<Cliente> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.ClienteId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.ClienteId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.ClienteId);

            return source;
        }

        protected override IQueryable<Cliente> MapperGetByFiltersToDomainFields(IQueryable<Cliente> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new Cliente
                {

                }).AsQueryable();
            }

            return result.Select(_ => (Cliente)_).AsQueryable();

        }

        protected override Cliente MapperGetOneToDomainFields(IQueryable<Cliente> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new Cliente
                {

                };
            }

            return source.SingleOrDefault();
        }

        protected override Expression<Func<Cliente, object>>[] DataAgregation(Expression<Func<Cliente, object>>[] includes, FilterBase filter)
        {
            return includes.Add(
                _ => _.Pessoa.Endereco,
                _ => _.StatusCliente,
                _ => _.Condominio);
        }

    }
}
