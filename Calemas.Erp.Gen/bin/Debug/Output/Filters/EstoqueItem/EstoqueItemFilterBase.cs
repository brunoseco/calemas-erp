using Common.Domain.Base;
using System;

namespace Calemas.Erp.ui.Domain.Filter
{
    public class EstoqueItemFilterBase : FilterBase
    {

        public int EstoqueItemId { get; set;} 
        public int EscolaId { get; set;} 
        public string Nome { get; set;} 
        public string Descricao { get; set;} 
        public bool? Ativo { get; set;} 
        public bool? Venda { get; set;} 
        public int UnidadeMedidaId { get; set;} 
        public int CategoriaEstoqueId { get; set;} 
        public bool? CompraViaCNAStore { get; set;} 
        public string ReferenciaCNAStore { get; set;} 
        public int? FornecedorId { get; set;} 
        public int UserCreateId { get; set;} 
        public DateTime UserCreateDateStart { get; set;} 
        public DateTime UserCreateDateEnd { get; set;} 
        public DateTime UserCreateDate { get; set;} 
        public int? UserAlterId { get; set;} 
        public DateTime? UserAlterDateStart { get; set;} 
        public DateTime? UserAlterDateEnd { get; set;} 
        public DateTime? UserAlterDate { get; set;} 


    }
}
