using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Entitys
{
    public class Condominio : CondominioBase
    {

        public Condominio()
        {

        }

        public Condominio(int condominioid, string nome, bool ativo) :
            base(condominioid, nome, ativo)
        {

        }

		    public class CondominioFactory
        {
            public Condominio GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new Condominio(data.CondominioId,
                                        data.Nome,
                                        data.Ativo);

                construction.SetarDescricao(data.Descricao);


				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new CondominioEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
