namespace Onion.Library.Domain.Feat_Product.Interfaces.Persistence
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Insert(T item);
        Task Update(T item);
        Task Delete(int id);
    }
}
