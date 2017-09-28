using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Entitys
{
    public class Condominio : CondominioBase
    {
        public virtual Endereco Endereco { get; set; }
        public Condominio()
        {

        }

        public Condominio(int condominioid, string nome, string sigla, bool ativo, int enderecoid) 
            : base(condominioid, nome, sigla, ativo, enderecoid)
        {
        }

        public class CondominioFactory
        {
            public Condominio GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new Condominio(data.CondominioId,
                                        data.Nome,
                                        data.Sigla,
                                        data.Ativo,
                                        data.EnderecoId);

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
