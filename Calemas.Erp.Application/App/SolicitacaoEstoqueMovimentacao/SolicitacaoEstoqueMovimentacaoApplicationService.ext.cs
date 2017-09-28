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
    public class SolicitacaoEstoqueMovimentacaoApplicationService : SolicitacaoEstoqueMovimentacaoApplicationServiceBase
    {

        public SolicitacaoEstoqueMovimentacaoApplicationService(ISolicitacaoEstoqueMovimentacaoService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache, user)
        {

        }

        protected override System.Collections.Generic.IEnumerable<TDS> MapperDomainToResult<TDS>(FilterBase filter, PaginateResult<SolicitacaoEstoqueMovimentacao> dataList)
        {
            return base.MapperDomainToResult<SolicitacaoEstoqueMovimentacaoDtoSpecializedResult>(filter, dataList) as IEnumerable<TDS>;
        }


        protected override async Task<SolicitacaoEstoqueMovimentacao> MapperDtoToDomain<TDS>(TDS dto)
        {
            return await Task.Run(() =>
            {
                var _dto = dto as SolicitacaoEstoqueMovimentacaoDto;

                if (!_dto.SolicitacaoEstoqueMovimentacaoId.IsSent())
                {
                    _dto.StatusSolicitacaoEstoqueMovimentacaoId = (int)EStatusSolicitacaoEstoqueMovimentacao.Pendente;
                    _dto.DataSolicitacao = DateTime.Now;
                }

                var domain = base.MapperDtoToDomain(_dto).Result;

                return domain;
            });
        }


    }
}
