using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;
using Calemas.Erp.Domain.Interfaces.Services;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Services
{
    public class ColaboradorService : ColaboradorServiceBase, IColaboradorService
    {
        public ColaboradorService(IColaboradorRepository rep, ICache cache, CurrentUser user)
            : base(rep, cache, user)
        {


        }

        public override Colaborador AuditDefault(Colaborador colaborador, Colaborador colaboradorOld)
        {
            var isNew = colaboradorOld.IsNull();
            if (isNew)
            {
                colaborador.SetUserCreate(this._user.GetSubjectId<int>());
                colaborador.Pessoa.SetUserCreate(this._user.GetSubjectId<int>());
            }
            else
            {
                colaborador.SetUserUpdate(this._user.GetSubjectId<int>());
                colaborador.SetUserCreate(colaboradorOld.UserCreateId, colaboradorOld.UserCreateDate);

                colaborador.Pessoa.SetUserUpdate(this._user.GetSubjectId<int>());
                colaborador.Pessoa.SetUserCreate(colaboradorOld.Pessoa.UserCreateId, colaboradorOld.Pessoa.UserCreateDate);
            }

            return colaborador;
        }

    }
}
