using Onion.Library.Domain.Interfaces.Persistence;

namespace Onion.Library.Domain.Feat_Product.Interfaces.Persistence
{
    public interface IRepositoryManager
    {
        IProductRepository ProductRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
