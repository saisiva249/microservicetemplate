using Microsoft.AspNetCore.Mvc;
using Onion.Library.Application.Feat_Product.ViewModels;
using Onion.Library.Domain.Feat_Product.Interfaces.Service;

namespace Onion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            var product = await _productService.GetProductById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductPostRequestViewModel productPostRequestViewModel)
        {
            var result = await _productService.CreateProduct(productPostRequestViewModel);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductPutResponseViewModel productPutResponseViewModel)
        {
            await _productService.UpdateProduct(id, productPutResponseViewModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productService.DeleteProduct(id);
            return Ok();
        }
    }
}
