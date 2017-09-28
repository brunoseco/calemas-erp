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

namespace Calemas.Erp.Application
{
    public class ClienteApplicationService : ClienteApplicationServiceBase
    {

        public ClienteApplicationService(IClienteService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache, user)
        {

        }

        protected override System.Collections.Generic.IEnumerable<TDS> MapperDomainToResult<TDS>(FilterBase filter, PaginateResult<Cliente> dataList)
        {
            return base.MapperDomainToResult<ClienteDtoSpecializedResult>(filter, dataList) as IEnumerable<TDS>;
        }


        protected override TDS MapperDomainToDto<TDS>(Cliente model)
        {
            return base.MapperDomainToDto<ClienteDtoSpecialized>(model) as TDS;
        }

        protected override async Task<Cliente> MapperDtoToDomain<TDS>(TDS dto)
        {
            return await Task.Run(() =>
            {
                var _dto = dto as ClienteDtoSpecialized;

                var domain = base.MapperDtoToDomain(_dto).Result;

                if (_dto.Pessoa.IsNotNull())
                {
                    domain.Pessoa = new Pessoa.PessoaFactory().GetDefaultInstance(_dto.Pessoa, this._user);

                    if (_dto.Pessoa.Endereco.IsNotNull())
                        domain.Pessoa.Endereco = new Endereco.EnderecoFactory().GetDefaultInstance(_dto.Pessoa.Endereco, this._user);
                }

                return domain;
            });
        }

    }
}
