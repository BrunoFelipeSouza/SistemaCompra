using MediatR;
using System;
using System.Collections.Generic;
using SistemaCompra.Domain.Core.Model;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        public string UsuarioSolicitante { get; private set; }
        public string NomeFornecedor { get; private set; }
        public IEnumerable<SolicitacaoCompraAgg.Item> Itens { get; private set; }
    }
}
