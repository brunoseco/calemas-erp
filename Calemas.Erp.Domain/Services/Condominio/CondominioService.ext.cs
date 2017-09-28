using Common.Domain.Interfaces;
using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;
using Calemas.Erp.Domain.Interfaces.Services;
using Common.Domain.Base;

namespace Calemas.Erp.Domain.Services
{
    public class CondominioService : CondominioServiceBase, ICondominioService
    {
        protected readonly IEnderecoRepository _repEndereco;

        public CondominioService(ICondominioRepository rep, IEnderecoRepository repEndereco, ICache cache, CurrentUser user)
            : base(rep, cache, user)
        {
            this._repEndereco = repEndereco;
        }

        public override Condominio AuditDefault(DomainBaseWithUserCreate entity, DomainBaseWithUserCreate entityOld)
        {
            var alvo = base.AuditDefault(entity, entityOld);
            if (alvo.Endereco.IsNotNull())
                base.AuditDefault(alvo.Endereco, entityOld);

            return alvo;
        }

        protected override Condominio UpdateDefault(Condominio entity, Condominio entityOld)
        {
            if (entity.Endereco.IsNotNull())
                _repEndereco.Update(entity.Endereco);

            return base.UpdateDefault(entity, entityOld);
        }
        
    }
}
