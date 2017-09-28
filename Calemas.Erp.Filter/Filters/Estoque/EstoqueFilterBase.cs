using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class EstoqueFilterBase : FilterBase
    {

        public virtual int EstoqueId { get; set;} 
        public virtual string Nome { get; set;} 
        public virtual string Descricao { get; set;} 
        public virtual string Modelo { get; set;} 
        public virtual string Fabricante { get; set;} 
        public virtual string Referencia { get; set;} 
        public virtual int UnidadeMedidaId { get; set;} 
        public virtual int CategoriaEstoqueId { get; set;} 
        public virtual string Observacao { get; set;} 
        public virtual decimal QuantidadeMinima { get; set;} 
        public virtual decimal Quantidade { get; set;} 
        public virtual decimal? ValorVenda { get; set;} 
        public virtual decimal? ValorCompra { get; set;} 
        public virtual bool? Ativo { get; set;} 
        public virtual string Localizacao { get; set;} 
        public virtual int UserCreateId { get; set;} 
        public virtual DateTime UserCreateDateStart { get; set;} 
        public virtual DateTime UserCreateDateEnd { get; set;} 
        public virtual DateTime UserCreateDate { get; set;} 
        public virtual int? UserAlterId { get; set;} 
        public virtual DateTime? UserAlterDateStart { get; set;} 
        public virtual DateTime? UserAlterDateEnd { get; set;} 
        public virtual DateTime? UserAlterDate { get; set;} 


    }
}
