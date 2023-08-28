using Onion.Library.Application.Feat_Product.ViewModels;

namespace Onion.Library.Domain.Feat_Product.Interfaces.Service
{
    public interface IProductService
    {
        Task<IEnumerable<ProductGetRequestViewModel>> GetAllProducts();
        Task<ProductGetRequestViewModel> GetProductById(int id);
        Task<ProductGetRequestViewModel> CreateProduct(ProductPostRequestViewModel productPostResponseModel);
        Task UpdateProduct(int id, ProductPutResponseViewModel productPutResponseModel);
        Task DeleteProduct(int id);
    }
}
