using Common.Domain.Interfaces;
using Calemas.Erp.Application.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using Calemas.Erp.Domain.Interfaces.Services;
using Calemas.Erp.Dto;
using System.Linq;
using System.Collections.Generic;
using Common.Domain.Base;
using Common.Domain.Model;
using System.Threading.Tasks;
using Calemas.Erp.Enums.Domain;
using System;

namespace Calemas.Erp.Application
{
    public class SolicitacaoEstoqueApplicationService : SolicitacaoEstoqueApplicationServiceBase
    {

        public SolicitacaoEstoqueApplicationService(ISolicitacaoEstoqueService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache, user)
        {
  
        }

        protected override System.Collections.Generic.IEnumerable<TDS> MapperDomainToResult<TDS>(FilterBase filter, PaginateResult<SolicitacaoEstoque> dataList)
        {
            return base.MapperDomainToResult<SolicitacaoEstoqueDtoSpecializedResult>(filter, dataList) as IEnumerable<TDS>;
        }

        protected override async Task<SolicitacaoEstoque> MapperDtoToDomain<TDS>(TDS dto)
        {
            return await Task.Run(() =>
            {
                var _dto = dto as SolicitacaoEstoqueDto;

                if (!_dto.SolicitacaoEstoqueId.IsSent())
                {
                    _dto.StatusSolicitacaoEstoqueMovimentacaoId = (int)EStatusSolicitacaoEstoqueMovimentacao.Pendente;
                    _dto.SolicitanteId = this._user.GetSubjectId<int>();
                    _dto.DataSolicitacao = DateTime.Now;
                }

                var domain = base.MapperDtoToDomain(_dto).Result;

                return domain;
            });
        }

    }
}
