using MediatR;
using Onion.Library.Domain.Feat_Product.Interfaces.Persistence;
using static Onion.Library.Domain.Feat_Product.Commands.ProductCommandContainer;

namespace Onion.Library.Application.Feat_Product.CommandHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IRepositoryManager m_repositoryManager;

        public UpdateProductCommandHandler(IRepositoryManager repositoryManager)
        {
            m_repositoryManager = repositoryManager;
        }

        //public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await m_repositoryManager.ProductRepository.Update(request.Product);
            await m_repositoryManager.UnitOfWork.SaveChanges();
        }
    }
}
