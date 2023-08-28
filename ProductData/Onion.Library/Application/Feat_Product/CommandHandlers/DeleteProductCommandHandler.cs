using MediatR;
using Onion.Library.Domain.Feat_Product.Interfaces.Persistence;
using static Onion.Library.Domain.Feat_Product.Commands.ProductCommandContainer;

namespace Onion.Library.Application.Feat_Product.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IRepositoryManager m_repositoryManager;
        public DeleteProductCommandHandler(IRepositoryManager repositoryManager)
        {
            m_repositoryManager = repositoryManager;
        }

        //public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await m_repositoryManager.ProductRepository.Delete(request.Id);
            await m_repositoryManager.UnitOfWork.SaveChanges();
        }
    }
}
