using Calemas.Erp.Domain.Validations;
using System;

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
            public CategoriaEstoque GetDefaaultInstance(dynamic data)
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
