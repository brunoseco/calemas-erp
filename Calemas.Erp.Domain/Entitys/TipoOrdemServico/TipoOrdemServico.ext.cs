using Calemas.Erp.Domain.Validations;
using Common.Domain.Model;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class TipoOrdemServico : TipoOrdemServicoBase
    {
        public virtual Prioridade Prioridade { get; set; }
        public virtual Setor Setor { get; set; }
        public TipoOrdemServico()
        {

        }

        public TipoOrdemServico(int tipoordemservicoid, string nome, int setorid, int prioridadeid, bool ativo) : base(tipoordemservicoid, nome, setorid, prioridadeid, ativo)
        {
        }

        public class TipoOrdemServicoFactory
        {
            public TipoOrdemServico GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new TipoOrdemServico(data.TipoOrdemServicoId,
                                        data.Nome,
                                        data.SetorId,
                                        data.PrioridadeId,
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
