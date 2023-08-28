using Onion.Library.Domain.Feat_Product.Interfaces.Persistence;
using Onion.Library.Domain.Interfaces.Persistence;

namespace Onion.Library.SPI.Persistence
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IUnitOfWork> m_unitOfWork;
        private readonly Lazy<IProductRepository> m_productRepository;

        public IProductRepository ProductRepository => m_productRepository.Value;
        public IUnitOfWork UnitOfWork => m_unitOfWork.Value;

        public RepositoryManager(RepositoryDbContext dbContext)
        {
            m_unitOfWork = new Lazy<IUnitOfWork>(()=>new UnitOfWork(dbContext));
            m_productRepository = new Lazy<IProductRepository>(()=>new ProductRepository(dbContext));
        }

    }
}
