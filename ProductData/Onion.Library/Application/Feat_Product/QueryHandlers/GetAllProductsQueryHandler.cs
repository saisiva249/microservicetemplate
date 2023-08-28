using MediatR;
using Onion.Library.Domain.Feat_Product.Entities;
using Onion.Library.Domain.Feat_Product.Interfaces.Persistence;
using static Onion.Library.Domain.Feat_Product.Queries.ProductQueryContainer;


namespace Onion.Library.Application.Feat_Product.QueryHandlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IRepositoryManager m_repositoryManager;
        public GetAllProductsQueryHandler(IRepositoryManager repositoryManager)
        {
            m_repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await m_repositoryManager.ProductRepository.GetAll();
        }
    }
}
