using AutoMapper;
using InmobiliariaUNAH.Database;
using InmobiliariaUNAH.Dtos.common;
using InmobiliariaUNAH.Dtos.Products;
using InmobiliariaUNAH.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaUNAH.Services
{
    public class ProductService : IProductService
    {
        private readonly InmobiliariaUNAHContext _context;
        private readonly IMapper _mapper;
        public ProductService(InmobiliariaUNAHContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<List<ProductDto>>> GetProductsListAsync()
        {
            var productsEntity = await _context.Products.ToListAsync();
            var productsDtos =_mapper.Map<List<ProductDto>>(productsEntity);

            return new ResponseDto<List<ProductDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Listado de registro obtenida correctamente",
                Data = productsDtos
            };
        }
        public Task<ResponseDto<ProductDto>> GetProductByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<ResponseDto<ProductDto>> CreateProductAsync(ProductCreateDto dto)
        {
            throw new NotImplementedException();
        }
        public Task<ResponseDto<ProductDto>> EditProductAsync(ProductEditDto dto, Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<ResponseDto<ProductDto>> DeleteProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
