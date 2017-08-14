using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Entitys
{
    public class StatusOrdemServico : StatusOrdemServicoBase
    {

        public StatusOrdemServico()
        {

        }

        public StatusOrdemServico(int statusordemservicoid, string nome, bool ativo) :
            base(statusordemservicoid, nome, ativo)
        {

        }

		    public class StatusOrdemServicoFactory
        {
            public StatusOrdemServico GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new StatusOrdemServico(data.StatusOrdemServicoId,
                                        data.Nome,
                                        data.Ativo);

                construction.SetarDescricao(data.Descricao);


				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new StatusOrdemServicoEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
