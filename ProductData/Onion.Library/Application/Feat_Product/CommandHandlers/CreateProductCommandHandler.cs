using MediatR;
using Onion.Library.Domain.Feat_Product.Entities;
using Onion.Library.Domain.Feat_Product.Interfaces.Persistence;
using static Onion.Library.Domain.Feat_Product.Commands.ProductCommandContainer;

namespace Onion.Library.Application.Feat_Product.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductComand, Product>
    {
        private readonly IRepositoryManager m_repositoryManager;

        public CreateProductCommandHandler(IRepositoryManager repositoryManager)
        {
            m_repositoryManager= repositoryManager;
        }
        public async Task<Product> Handle(CreateProductComand request, CancellationToken cancellationToken)
        {
           var product = await m_repositoryManager.ProductRepository.Insert(request.Product);
           await m_repositoryManager.UnitOfWork.SaveChanges();
           return product;
        }
    }
}
