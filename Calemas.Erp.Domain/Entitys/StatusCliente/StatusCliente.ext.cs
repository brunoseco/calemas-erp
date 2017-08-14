using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Entitys
{
    public class StatusCliente : StatusClienteBase
    {

        public StatusCliente()
        {

        }

        public StatusCliente(int statusclienteid, string nome, bool ativo) :
            base(statusclienteid, nome, ativo)
        {

        }

		    public class StatusClienteFactory
        {
            public StatusCliente GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new StatusCliente(data.StatusClienteId,
                                        data.Nome,
                                        data.Ativo);

                construction.SetarDescricao(data.Descricao);


				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new StatusClienteEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
