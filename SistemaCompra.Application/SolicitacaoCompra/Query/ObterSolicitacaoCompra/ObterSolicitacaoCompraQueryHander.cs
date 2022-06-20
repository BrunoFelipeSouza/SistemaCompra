using AutoMapper;
using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaCompra.Application.SolicitacaoCompra.Query.ObterSolicitacaoCompra
{
    public class ObterSolicitacaoCompraQueryHander : IRequestHandler<ObterSolicitacaoCompraQuery, ObterSolicitacaoCompraViewModel>
    {
        private readonly ISolicitacaoCompraRepository solicitacaoCompraRepository;
        private readonly IMapper mapper;

        public ObterSolicitacaoCompraQueryHander(ISolicitacaoCompraRepository solicitacaoCompraRepository, IMapper mapper)
        {
            this.solicitacaoCompraRepository = solicitacaoCompraRepository;
            this.mapper = mapper;
        }
        public Task<ObterSolicitacaoCompraViewModel> Handle(ObterSolicitacaoCompraQuery request, CancellationToken cancellationToken)
        {
            var solicitacaoCompra = solicitacaoCompraRepository.Obter(request.Id);
            var solicitacaoCompraViewModel = mapper.Map<ObterSolicitacaoCompraViewModel>(solicitacaoCompra);

            return Task.FromResult(solicitacaoCompraViewModel);
        }
    }
}
