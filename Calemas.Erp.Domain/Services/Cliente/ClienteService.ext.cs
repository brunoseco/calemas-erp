using Common.Domain.Interfaces;
using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;
using Calemas.Erp.Domain.Interfaces.Services;
using Common.Domain.Base;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Services
{
    public class ClienteService : ClienteServiceBase, IClienteService
    {
        protected readonly IPessoaRepository _repPessoa;

        public ClienteService(IClienteRepository rep, IPessoaRepository _repPessoa, ICache cache, CurrentUser user)
            : base(rep, cache, user)
        {
            this._repPessoa = _repPessoa;
        }

        public override Task<Cliente> DomainOrchestration(Cliente entity, Cliente entityOld)
        {
            if (entity.Pessoa.IsNotNull())
                base.AuditDefault(entity.Pessoa, entityOld?.Pessoa);

            return base.DomainOrchestration(entity, entityOld);
        }

        protected override Cliente UpdateDefault(Cliente cliente)
        {
            if (cliente.Pessoa.IsNotNull())
                _repPessoa.Update(cliente.Pessoa);

            return base.UpdateDefault(cliente);
        }

    }
}
