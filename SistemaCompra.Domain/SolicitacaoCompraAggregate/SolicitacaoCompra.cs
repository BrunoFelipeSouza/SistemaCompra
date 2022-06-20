using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }
        public Money TotalGeral { get; private set; } 
        public Situacao Situacao { get; private set; }
        public CondicaoPagamento CondicaoPagamento { get; private set; }

        private SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;
        }

        public void AdicionarItem(Produto produto, int qtde)
        {
        }

        public void RegistrarCompra(IEnumerable<Item> itens)
        {
            decimal totalGeral = 0;
            int totalItens = 0;
            Itens = new List<Item>();
            foreach (Item item in itens) 
            {
                Itens.Add(item);
                totalGeral += item.Subtotal.Value;
                totalItens += item.Qtde;
            }
            TotalGeral = new Money(totalGeral);

            if (TotalGeral.Value > 50000)
            {
                CondicaoPagamento condicaoPagamento = new CondicaoPagamento(30);
                CondicaoPagamento = condicaoPagamento;
            }
            else
            {
                CondicaoPagamento condicaoPagamento = new CondicaoPagamento(60);
                CondicaoPagamento = condicaoPagamento;
            }
            if (totalItens == 0) throw new BusinessRuleException("A solicitação de compra deve possuir itens!");

            AddEvent(new CompraRegistradaEvent(Id, itens, TotalGeral.Value));
        }
    }
}
