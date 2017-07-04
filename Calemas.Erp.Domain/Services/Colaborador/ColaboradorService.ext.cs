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

        public override Colaborador AuditDefault(DomainBaseWithUserCreate entity, DomainBaseWithUserCreate entityOld)
        {
            var colaborador = base.AuditDefault(entity, entityOld);
            if (colaborador.Pessoa.IsNotNull())
            {
                var isNew = entityOld.IsNull();
                base.AuditDefault(colaborador.Pessoa, isNew ? null : colaborador.Pessoa);
            }

            return colaborador;
        }

    }
}
