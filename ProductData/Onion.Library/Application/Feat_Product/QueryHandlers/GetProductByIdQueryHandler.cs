using MediatR;
using Onion.Library.Domain.Feat_Product.Entities;
using Onion.Library.Domain.Feat_Product.Interfaces.Persistence;
using static Onion.Library.Domain.Feat_Product.Queries.ProductQueryContainer;

namespace Onion.Library.Application.Feat_Product.QueryHandlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IRepositoryManager m_repositoryManager;
        public GetProductByIdQueryHandler(IRepositoryManager repositoryManager)
        {
            m_repositoryManager = repositoryManager;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await m_repositoryManager.ProductRepository.GetById(request.Id);
        }
    }
}
