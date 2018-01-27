using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Entitys
{
    public class MotivoEstoqueMovimentacao : MotivoEstoqueMovimentacaoBase
    {

        public MotivoEstoqueMovimentacao()
        {

        }

        public MotivoEstoqueMovimentacao(int motivoestoquemovimentacaoid, string nome) :
            base(motivoestoquemovimentacaoid, nome)
        {

        }

		public class MotivoEstoqueMovimentacaoFactory : MotivoEstoqueMovimentacaoFactoryBase
        {
            public MotivoEstoqueMovimentacao GetDefaultInstance(dynamic data, CurrentUser user)
            {
                return this.GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = new MotivoEstoqueMovimentacaoEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
