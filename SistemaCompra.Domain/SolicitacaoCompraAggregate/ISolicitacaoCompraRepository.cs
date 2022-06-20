using System;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public interface ISolicitacaoCompraRepository
    {
        SolicitacaoCompra Obter(Guid id);
        void RegistrarCompra(SolicitacaoCompra solicitacaoCompra);
        void Atualizar(SolicitacaoCompra entity);
        void Excluir(SolicitacaoCompra entity);
    }

}
