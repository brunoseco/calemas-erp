using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Dto;
using Calemas.Erp.Application.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using Calemas.Erp.Domain.Interfaces.Services;
using Calemas.Erp.Dto;
using System.Threading.Tasks;

namespace Calemas.Erp.Application
{
    public class OrdemServicoApplicationServiceBase : ApplicationServiceBase<OrdemServico, OrdemServicoDto, OrdemServicoFilter>, IOrdemServicoApplicationService
    {
        protected readonly ValidatorAnnotations<OrdemServicoDto> _validatorAnnotations;
        protected readonly IOrdemServicoService _service;

        public OrdemServicoApplicationServiceBase(IOrdemServicoService service, IUnitOfWork uow, ICache cache) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("OrdemServico");
            this._validatorAnnotations = new ValidatorAnnotations<OrdemServicoDto>();
            this._service = service;
        }


        protected override OrdemServico MapperDtoToDomain<TDS>(TDS dto)
        {
			var _dto = dto as OrdemServicoDtoSpecialized;
            this._validatorAnnotations.Validate(_dto);
            this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());

			var domain = new OrdemServico.OrdemServicoFactory().GetDefaaultInstance(_dto);
            return domain;
        }


        protected override async Task<OrdemServico> AlterDomainWithDto<TDS>(TDS dto)
        {
			var ordemservico = dto as OrdemServicoDto;
            var result = await this._serviceBase.GetOne(new OrdemServicoFilter { OrdemServicoId = ordemservico.OrdemServicoId });

            //Inicio da Transferencia dos valores
           

            //Fim da Transferencia dos valores

            return result;
        }

    }
}
