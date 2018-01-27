using Calemas.Erp.Domain.Validations;
using Common.Domain.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calemas.Erp.Domain.Entitys
{
    public class EstoqueMovimentacao : EstoqueMovimentacaoBase
    {
        public virtual Estoque Estoque { get; set; }
        public virtual Colaborador Colaborador { get; set; }
        public virtual EstoqueMovimentacaoColaborador EstoqueMovimentacaoColaborador { get; set; }

        [NotMapped]
        public bool AtualizaEstoqueColaborador { get; set; }

        public EstoqueMovimentacao()
        {

        }

        public EstoqueMovimentacao(int estoquemovimentacaoid, int estoqueid, bool entrada, string descricao, decimal quantidade, int responsavelid) :
            base(estoquemovimentacaoid, estoqueid, entrada, descricao, quantidade, responsavelid)
        {

        }


        public class EstoqueMovimentacaoFactory
        {
            public EstoqueMovimentacao GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new EstoqueMovimentacao(data.EstoqueMovimentacaoId,
                                        data.EstoqueId,
                                        data.Entrada,
                                        data.Descricao,
                                        data.Quantidade,
                                        data.ResponsavelId);

                construction.SetarAtualizaEstoqueColaborador(data.AtualizaEstoqueColaborador);

                return construction;
            }

        }

        public virtual void SetarAtualizaEstoqueColaborador(bool atualizaEstoqueColaborador)
        {
            this.AtualizaEstoqueColaborador = atualizaEstoqueColaborador;
        }

        public bool IsValid()
        {
            base._validationResult = new EstoqueMovimentacaoEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }

    }
}
