using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class EstoqueMovimentacaoBase : DomainBaseWithUserCreate
    {
        public EstoqueMovimentacaoBase()
        {

        }
        public EstoqueMovimentacaoBase(int estoquemovimentacaoid, int estoqueid, bool entrada, string descricao, decimal quantidade, int responsavelid)
        {
            this.EstoqueMovimentacaoId = estoquemovimentacaoid;
            this.EstoqueId = estoqueid;
            this.Entrada = entrada;
            this.Descricao = descricao;
            this.Quantidade = quantidade;
            this.ResponsavelId = responsavelid;

        }

        public int EstoqueMovimentacaoId { get; protected set; }
        public int EstoqueId { get; protected set; }
        public bool Entrada { get; protected set; }
        public string Descricao { get; protected set; }
        public decimal Quantidade { get; protected set; }
        public int ResponsavelId { get; protected set; }




    }
}
