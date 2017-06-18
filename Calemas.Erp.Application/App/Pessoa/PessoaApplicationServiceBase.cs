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
    public class PessoaApplicationServiceBase : ApplicationServiceBase<Pessoa, PessoaDto, PessoaFilter>, IPessoaApplicationService
    {
        protected readonly ValidatorAnnotations<PessoaDto> _validatorAnnotations;
        protected readonly IPessoaService _service;

        public PessoaApplicationServiceBase(IPessoaService service, IUnitOfWork uow, ICache cache) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("Pessoa");
            this._validatorAnnotations = new ValidatorAnnotations<PessoaDto>();
            this._service = service;
        }


        protected override Pessoa MapperDtoToDomain<TDS>(TDS dto)
        {
			var _dto = dto as PessoaDto;
            this._validatorAnnotations.Validate(_dto);
            this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());

            var domain = new Pessoa(_dto.PessoaId,
                                        _dto.Nome,
                                        _dto.Apelido);

            domain.SetarCPF_CNPJ(_dto.CPF_CNPJ);
            domain.SetarRG_IE(_dto.RG_IE);
            domain.SetarEmail(_dto.Email);
            domain.SetarTelefone(_dto.Telefone);
            domain.SetarCelular(_dto.Celular);
            domain.SetarComercial(_dto.Comercial);
            domain.SetarDataNascimento(_dto.DataNascimento);
            domain.SetarEstadoCivilId(_dto.EstadoCivilId);
            domain.SetarSexo(_dto.Sexo);
            domain.SetarJuridica(_dto.Juridica);
            domain.SetarEnderecoId(_dto.EnderecoId);


            return domain;
        }


        protected override async Task<Pessoa> AlterDomainWithDto<TDS>(TDS dto)
        {
			var pessoa = dto as PessoaDto;
            var result = await this._serviceBase.GetOne(new PessoaFilter { PessoaId = pessoa.PessoaId });

            //Inicio da Transferencia dos valores
           

            //Fim da Transferencia dos valores

            return result;
        }

    }
}
