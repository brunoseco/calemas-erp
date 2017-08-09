using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Entitys
{
    public class CategoriaEstoque : CategoriaEstoqueBase
    {

        public CategoriaEstoque()
        {

        }

        public CategoriaEstoque(int categoriaestoqueid, string nome) :
            base(categoriaestoqueid, nome)
        {

        }

		public class CategoriaEstoqueFactory
        {
            public CategoriaEstoque GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new CategoriaEstoque(data.CategoriaEstoqueId,
                                        data.Nome);



				return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new CategoriaEstoqueEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
