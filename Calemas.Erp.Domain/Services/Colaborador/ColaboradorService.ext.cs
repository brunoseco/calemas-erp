using Common.Domain.Interfaces;
using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;
using Calemas.Erp.Domain.Interfaces.Services;
using Common.Domain.Base;

namespace Calemas.Erp.Domain.Services
{
    public class ColaboradorService : ColaboradorServiceBase, IColaboradorService
    {
        protected readonly IPessoaRepository _repPessoa;

        public ColaboradorService(IColaboradorRepository rep, IPessoaRepository repPessoa, ICache cache, CurrentUser user)
            : base(rep, cache, user)
        {
            this._repPessoa = repPessoa;

        }

        public override Colaborador AuditDefault(Colaborador entity, Colaborador entityOld)
        {
            if (entity.Pessoa.IsNotNull())
            {
                var isNew = entityOld.IsNull();
                base.AuditDefault(entity.Pessoa, isNew ? null : entityOld.Pessoa);
            }

            return base.AuditDefault(entity, entityOld);
        }

    }
}
