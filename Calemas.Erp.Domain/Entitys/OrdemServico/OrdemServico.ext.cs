using Calemas.Erp.Domain.Validations;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class OrdemServico : OrdemServicoBase
    {

        public OrdemServico()
        {

        }

        public OrdemServico(int ordemservicoid, string protoco, int responsavelid, int clienteid, int prioridadeid, int setorid, int tipoordemservicoid, int agendaid, int statusordemservicoid, DateTime dataocorrencia, DateTime datasituacao)
            : base(ordemservicoid, protoco, responsavelid, clienteid, prioridadeid, setorid, tipoordemservicoid, agendaid, statusordemservicoid, dataocorrencia, datasituacao)
        { }

        public class OrdemServicoFactory
        {
            public OrdemServico GetDefaaultInstance(dynamic data)
            {
                var construction = new OrdemServico(data.OrdemServicoId,
                                        data.Protoco,
                                        data.ResponsavelId,
                                        data.ClienteId,
                                        data.PrioridadeId,
                                        data.SetorId,
                                        data.TipoOrdemServicoId,
                                        data.AgendaId,
                                        data.StatusOrdemServicoId,
                                        data.DataOcorrencia,
                                        data.DataSituacao);

                construction.SetarObservacao(data.Observacao);
                construction.SetarDescricao(data.Descricao);


                return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new OrdemServicoEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }

    }
}
