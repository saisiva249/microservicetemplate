namespace Onion.Library.Domain.Interfaces.Persistence
{
    public  interface IUnitOfWork
    {
        Task<int> SaveChanges();
    }
}
