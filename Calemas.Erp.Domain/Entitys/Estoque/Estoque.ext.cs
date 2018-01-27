using Calemas.Erp.Domain.Validations;
using Common.Domain.Model;
using System;
using System.Collections.Generic;

namespace Calemas.Erp.Domain.Entitys
{
    public class Estoque : EstoqueBase
    {
        public virtual CategoriaEstoque CategoriaEstoque { get; set; }
        public virtual ICollection<EstoqueMovimentacao> CollectionEstoqueMovimentacao { get; set; }
        public Estoque()
        {

        }

        public Estoque(int estoqueid, string nome, int unidademedidaid, int categoriaestoqueid, decimal quantidademinima, decimal quantidade, bool ativo) :
            base(estoqueid, nome, unidademedidaid, categoriaestoqueid, quantidademinima, quantidade, ativo)
        {

        }

        public class EstoqueFactory
        {
            public Estoque GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new Estoque(data.EstoqueId,
                                        data.Nome,
                                        data.UnidadeMedidaId,
                                        data.CategoriaEstoqueId,
                                        data.QuantidadeMinima,
                                        data.Quantidade,
                                        data.Ativo);

                construction.SetarDescricao(data.Descricao);
                construction.SetarReferencia(data.Referencia);
                construction.SetarObservacao(data.Observacao);
                construction.SetarValorVenda(data.ValorVenda);
                construction.SetarValorCompra(data.ValorCompra);
                construction.SetarModelo(data.Modelo);
                construction.SetarFabricante(data.Fabricante);
                construction.SetarLocalizacao(data.Localizacao);

                return construction;
            }

        }

        public void AtualizarQuantidade(decimal quantidade, bool entrada)
        {
            if (entrada)
                this.Quantidade += quantidade;
            else
                this.Quantidade -= quantidade;
        }

        public bool IsValid()
        {
            base._validationResult = new EstoqueEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }

    }
}
