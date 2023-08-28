using AutoMapper;
using MediatR;
using Onion.Library.Application.Feat_Product.ViewModels;
using Onion.Library.Domain.Feat_Product.Commands;
using Onion.Library.Domain.Feat_Product.Entities;
using Onion.Library.Domain.Feat_Product.Interfaces.Service;
using Onion.Library.Domain.Feat_Product.Queries;

namespace Onion.Library.Application.Feat_Product.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator m_Mediator;
        private readonly IMapper m_Mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            m_Mapper= mapper;
            m_Mediator = mediator;
        }

        public async Task<IEnumerable<ProductGetRequestViewModel>> GetAllProducts()
        {
            try
            {
                var getAllProductsCommand = new ProductQueryContainer.GetAllProductsQuery();
                var products = await m_Mediator.Send(getAllProductsCommand);
                return m_Mapper.Map<IEnumerable<ProductGetRequestViewModel>>(products);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductGetRequestViewModel> GetProductById(int id)
        {
            try
            {
                var getProductByIdCommand = new ProductQueryContainer.GetProductByIdQuery(id);
                var product = await m_Mediator.Send(getProductByIdCommand);
                return m_Mapper.Map<ProductGetRequestViewModel>(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductGetRequestViewModel> CreateProduct(ProductPostRequestViewModel productPostResponseModel)
        {
            try
            {
                var product = m_Mapper.Map<Product>(productPostResponseModel);
                var createProductCommand = new ProductCommandContainer.CreateProductComand(product);
                var insertedProduct = await m_Mediator.Send(createProductCommand);
                return m_Mapper.Map<ProductGetRequestViewModel>(insertedProduct);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); 
            }
        }

        public async Task UpdateProduct(int id, ProductPutResponseViewModel productPutResponseModel)
        {
            try
            {
                var product = m_Mapper.Map<Product>(productPutResponseModel);
                product.Id = id;
                var updateProductCommand = new ProductCommandContainer.UpdateProductCommand(product);
                await m_Mediator.Send(updateProductCommand);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteProduct(int id)
        {
            try
            {
                var deleteProductCommand = new ProductCommandContainer.DeleteProductCommand(id);
                await m_Mediator.Send(deleteProductCommand);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
