using Calemas.Erp.Domain.Validations;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class TipoOrdemServico : TipoOrdemServicoBase
    {

        public TipoOrdemServico()
        {

        }

        public TipoOrdemServico(int tipoordemservicoid, string nome, bool ativo) :
            base(tipoordemservicoid, nome, ativo)
        {

        }

		public class TipoOrdemServicoFactory
        {
            public TipoOrdemServico GetDefaaultInstance(dynamic data)
            {
                var construction = new TipoOrdemServico(data.TipoOrdemServicoId,
                                        data.Nome,
                                        data.Ativo);

                construction.SetarDescricao(data.Descricao);


				return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new TipoOrdemServicoEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
