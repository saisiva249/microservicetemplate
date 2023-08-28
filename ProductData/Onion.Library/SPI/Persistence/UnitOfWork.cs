using Onion.Library.Domain.Interfaces.Persistence;

namespace Onion.Library.SPI.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryDbContext m_dbContext;
        public UnitOfWork(RepositoryDbContext dbContext) => m_dbContext = dbContext;

        public Task<int> SaveChanges()
        {
            return m_dbContext.SaveChangesAsync();
        }
    }
}
