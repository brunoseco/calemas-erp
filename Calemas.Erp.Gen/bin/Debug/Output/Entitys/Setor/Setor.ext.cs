using Calemas.Erp.Domain.Validations;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class Setor : SetorBase
    {

        public Setor()
        {

        }

        public Setor(int setorid, string nome, string cor, bool ativo) :
            base(setorid, nome, cor, ativo)
        {

        }

		public class SetorFactory
        {
            public Setor GetDefaaultInstance(dynamic data)
            {
                var construction = new Setor(data.SetorId,
                                        data.Nome,
                                        data.Cor,
                                        data.Ativo);

                construction.SetarDescricao(data.Descricao);


				return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new SetorEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
