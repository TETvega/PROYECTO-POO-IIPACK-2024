using InmobiliariaUNAH.Dtos.common;
using InmobiliariaUNAH.Dtos.Products;
using InmobiliariaUNAH.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InmobiliariaUNAH.Controllers
{
    [ApiController] 
    [Route("api/products")] 
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<NoteDt>>> GetAll()
        {
            var response = await _productService.GetProductsListAsync();
            return StatusCode(response.StatusCode, response);
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<ResponseDto<NoteDt>>> Get(Guid id)
        {
            var response = await _productService.GetProductByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<NoteDt>>> Create(ProductCreateDto dto)
        {
            var response = await _productService.CreateProductAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<ResponseDto<NoteDt>>> Edit(ProductEditDto dto, Guid id)
        {
            var response = await _productService.EditProductAsync(dto, id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<ResponseDto<NoteDt>>> Delete(Guid id)
        {
            var response = await _productService.DeleteProductAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
