using Common.Domain.Interfaces;
using Calemas.Erp.Application.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using Calemas.Erp.Domain.Interfaces.Services;
using Calemas.Erp.Dto;
using System.Linq;
using System.Collections.Generic;
using Common.Domain.Base;

namespace Calemas.Erp.Application
{
    public class ColaboradorApplicationService : ColaboradorApplicationServiceBase
    {

        public ColaboradorApplicationService(IColaboradorService service, IUnitOfWork uow, ICache cache) :
            base(service, uow, cache)
        {

        }

        protected override IEnumerable<TDS> MapperDomainToResult<TDS>(FilterBase filter, PaginateResult<Colaborador> dataList)
        {
            return base.MapperDomainToResult<ColaboradorDtoSpecializedResult>(filter, dataList) as IEnumerable<TDS>;
        }

        protected override TDS MapperDomainToDto<TDS>(Colaborador model)
        {
            return base.MapperDomainToDto<ColaboradorDtoSpecializedDetails>(model) as TDS;
        }

        protected override Colaborador MapperDtoToDomain<TDS>(TDS dto)
        {
            var _dto = dto as ColaboradorDtoSpecialized;
            this._validatorAnnotations.Validate(_dto);
            this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());

            var domain = new Colaborador.FactoryColaborador().GetInstance(_dto);

            //var domain = new Colaborador(_dto.ColaboradorId,
            //                            _dto.Account,
            //                            _dto.Password,
            //                            _dto.Ativo,
            //                            _dto.Pessoa.PessoaId,
            //                            _dto.Pessoa.Nome,
            //                            _dto.Pessoa.Apelido,
            //                            _dto.Pessoa.CPF_CNPJ,
            //                            _dto.Pessoa.RG_IE,
            //                            _dto.Pessoa.Email,
            //                            _dto.Pessoa.Telefone,
            //                            _dto.Pessoa.Celular,
            //                            _dto.Pessoa.Comercial,
            //                            _dto.Pessoa.DataNascimento,
            //                            _dto.Pessoa.EstadoCivilId,
            //                            _dto.Pessoa.Sexo,
            //                            _dto.Pessoa.Juridica);

            return domain;
        }

    }
}
