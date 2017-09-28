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
        protected readonly IEnderecoRepository _repEndereco;

        public ClienteService(IClienteRepository rep, IPessoaRepository _repPessoa, IEnderecoRepository _repEndereco, ICache cache, CurrentUser user)
            : base(rep, cache, user)
        {
            this._repPessoa = _repPessoa;
            this._repEndereco = _repEndereco;
        }

        public override Cliente AuditDefault(DomainBaseWithUserCreate entity, DomainBaseWithUserCreate entityOld)
        {
            var alvo = base.AuditDefault(entity, entityOld);
            if (alvo.Pessoa.IsNotNull())
            {
                base.AuditDefault(alvo.Pessoa, entityOld);

                if (alvo.Pessoa.Endereco.IsNotNull())
                {
                    var alvoOld = entityOld as Cliente;
                    base.AuditDefault(alvo.Pessoa.Endereco, alvoOld?.Pessoa?.Endereco);
                }
            }

            return alvo;
        }

        protected override Cliente UpdateDefault(Cliente cliente, Cliente clienteOld)
        {
            if (cliente.Pessoa.IsNotNull())
            {
                _repPessoa.Update(cliente.Pessoa);

                if (cliente.Pessoa.Endereco.IsNotNull())
                    _repEndereco.Update(cliente.Pessoa.Endereco);
            }

            return base.UpdateDefault(cliente, clienteOld);
        }

    }
}
