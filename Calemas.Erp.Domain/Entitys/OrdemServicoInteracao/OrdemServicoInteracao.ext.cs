using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Entitys
{
    public class OrdemServicoInteracao : OrdemServicoInteracaoBase
    {

        public OrdemServicoInteracao()
        {

        }

        public OrdemServicoInteracao(int ordemservicointeracaoid, int ordemservicoid, DateTime dataconclusao, string descricao, bool foipropriocliente, int tecnicoid, int statusordemservicointeracaoid) :
            base(ordemservicointeracaoid, ordemservicoid, dataconclusao, descricao, foipropriocliente, tecnicoid, statusordemservicointeracaoid)
        {

        }

		    public class OrdemServicoInteracaoFactory
        {
            public OrdemServicoInteracao GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new OrdemServicoInteracao(data.OrdemServicoInteracaoId,
                                        data.OrdemServicoId,
                                        data.DataConclusao,
                                        data.Descricao,
                                        data.FoiProprioCliente,
                                        data.TecnicoId,
                                        data.StatusOrdemServicoInteracaoId);

                construction.SetarObservacao(data.Observacao);
                construction.SetarNomeClienteResponsavel(data.NomeClienteResponsavel);


				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new OrdemServicoInteracaoEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
