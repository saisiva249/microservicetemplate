using MediatR;
using Onion.Library.Domain.Feat_Product.Entities;

namespace Onion.Library.Domain.Feat_Product.Queries
{
    public class ProductQueryContainer
    {
        public record GetAllProductsQuery() : IRequest<IEnumerable<Product>>;
        public record GetProductByIdQuery(int Id) : IRequest<Product>;
    }
}
