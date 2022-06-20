using System;
using System.Collections.Generic;
using System.Text;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Query.ObterSolicitacaoCompra
{
    public class ObterSolicitacaoCompraViewModel
    {
        public string UsuarioSolicitante { get; set; }
        public string NomeFornecedor { get; set; }
        public IList<SolicitacaoCompraAgg.Item> Itens { get; set; }
        public DateTime Data { get; set; }
        public decimal TotalGeral { get; set; }
        public int Situacao { get; set; }
        public int CondicaoPagamento { get; set; }
    }
}
