using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Dto;
using Calemas.Erp.Application.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using Calemas.Erp.Domain.Interfaces.Services;
using Calemas.Erp.Dto;

namespace Calemas.Erp.Application
{
    public class BancoApplicationServiceBase : ApplicationServiceBase<Banco, BancoDto, BancoFilter>, IBancoApplicationService
    {
        protected readonly ValidatorAnnotations<BancoDto> _validatorAnnotations;
        protected readonly IBancoService _service;

        public BancoApplicationServiceBase(IBancoService service, IUnitOfWork uow, ICache cache) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("Banco");
            this._validatorAnnotations = new ValidatorAnnotations<BancoDto>();
            this._service = service;
        }


        protected override Banco MapperDtoToDomain<TDS>(TDS dto)
        {
			var _dto = dto as BancoDto;
            this._validatorAnnotations.Validate(_dto);
            this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());

            var domain = new Banco(_dto.BancoId,
                                        _dto.Nome,
                                        _dto.BoletoSemRegistro,
                                        _dto.BoletoComRegistro,
                                        _dto.Ativo);

            domain.SetarNumero(_dto.Numero);
            domain.SetarDigito(_dto.Digito);


            return domain;
        }


        protected override Banco AlterDomainWithDto<TDS>(TDS dto)
        {
			var banco = dto as BancoDto;
            var result = this._serviceBase.GetOne(new BancoFilter { BancoId = banco.BancoId });
            
            //Inicio da Transferencia dos valores
           

            //Fim da Transferencia dos valores
            return result;
        }

    }
}
