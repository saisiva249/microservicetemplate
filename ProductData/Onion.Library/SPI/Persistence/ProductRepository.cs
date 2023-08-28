using Microsoft.EntityFrameworkCore;
using Onion.Library.Domain.Feat_Product.Entities;
using Onion.Library.Domain.Feat_Product.Interfaces.Persistence;

namespace Onion.Library.SPI.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly RepositoryDbContext m_DbContext;

        public ProductRepository(RepositoryDbContext context)
        {
            m_DbContext = context;
        }

        public async Task Delete(int id)
        {
            try
            {
                var product = await m_DbContext.Products.FindAsync(id);
                if (product != null)
                {
                    m_DbContext.Products.Remove(product);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            try
            {
                return await m_DbContext.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> GetById(int id)
        {
            try
            {
                return await m_DbContext.Products.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> Insert(Product product)
        {
            try
            {
                await m_DbContext.Products.AddAsync(product);
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(Product product)
        {
            try
            {
                var product_exists = await m_DbContext.Products.FindAsync(product.Id);
                if(product_exists!=null)
                {
                    product_exists.Name= product.Name;
                    m_DbContext.Products.Update(product_exists);
                }
            }
            catch (Exception  ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
