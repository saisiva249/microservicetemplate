using MediatR;
using Onion.Library.Domain.Feat_Product.Entities;

namespace Onion.Library.Domain.Feat_Product.Commands
{
    public class ProductCommandContainer
    {
        public record CreateProductComand(Product Product) : IRequest<Product>;
        public record UpdateProductCommand(Product Product) : IRequest;
        public record DeleteProductCommand(int Id) : IRequest;
    }
}
