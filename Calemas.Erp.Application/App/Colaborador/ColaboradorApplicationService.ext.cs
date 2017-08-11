using Common.Domain.Interfaces;
using Calemas.Erp.Application.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using Calemas.Erp.Domain.Interfaces.Services;
using Calemas.Erp.Dto;
using System.Linq;
using System.Collections.Generic;
using Common.Domain.Base;
using System.Threading.Tasks;
using Common.Domain.Model;

namespace Calemas.Erp.Application
{
    public class ColaboradorApplicationService : ColaboradorApplicationServiceBase
    {

        public ColaboradorApplicationService(IColaboradorService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache, user)
        {

        }

        protected override System.Collections.Generic.IEnumerable<TDS> MapperDomainToResult<TDS>(FilterBase filter, PaginateResult<Colaborador> dataList)
        {
            return base.MapperDomainToResult<ColaboradorDtoSpecializedResult>(filter, dataList) as IEnumerable<TDS>;
        }

        protected override TDS MapperDomainToDto<TDS>(Colaborador model)
        {
            return base.MapperDomainToDto<ColaboradorDtoSpecialized>(model) as TDS;
        }

        protected override async Task<Colaborador> MapperDtoToDomain<TDS>(TDS dto)
        {
            return await Task.Run(() =>
            {
                var _dto = dto as ColaboradorDtoSpecialized;

                var domain = base.MapperDtoToDomain(_dto).Result;

                if (_dto.Pessoa.IsNotNull())
                    domain.Pessoa = new Pessoa.PessoaFactory().GetDefaultInstance(_dto.Pessoa, this._user);

                return domain;
            });
        }

        protected override async Task<Colaborador> AlterDomainWithDto<TDS>(TDS dto)
        {
            var colaborador = dto as ColaboradorDto;
            var result = await this._serviceBase.GetOne(new ColaboradorFilter { ColaboradorId = colaborador.ColaboradorId });
            return result;
        }

    }
}
