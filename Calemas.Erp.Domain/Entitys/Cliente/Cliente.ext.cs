using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Entitys
{
    public class Cliente : ClienteBase
    {

        public Cliente()
        {

        }

        public Cliente(int clienteid, int statusclienteid) : base(clienteid, statusclienteid)
        {
        }

        public virtual Pessoa Pessoa { get; set; }
        public virtual StatusCliente StatusCliente { get; set; }
        public virtual Condominio Condominio { get; set; }
        
        public class ClienteFactory
        {
            public Cliente GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new Cliente(data.ClienteId,
                                        data.StatusClienteId);

                construction.SetarCondominioId(data.CondominioId);


                construction.SetAttributeBehavior(data.AttributeBehavior);
                return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new ClienteEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }

    }
}
