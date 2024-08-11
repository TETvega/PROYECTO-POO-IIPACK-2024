using AutoMapper;
using InmobiliariaUNAH.Database;
using InmobiliariaUNAH.Database.Entities;
using InmobiliariaUNAH.Dtos.common;
using InmobiliariaUNAH.Dtos.Products;
using InmobiliariaUNAH.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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

        public async Task<ResponseDto<List<ProductDto>>> GetProductsListByCategoryIdAsync(Guid id)
        {
            var productsEntity = await _context.Products.Where(p => p.CategoryId == id).ToListAsync();

            if (!productsEntity.Any())
            {
                return new ResponseDto<List<ProductDto>>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontraron productos en esta categoría",
                };
            }

            var productsDtos = _mapper.Map<List<ProductDto>>(productsEntity);

            return new ResponseDto<List<ProductDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Listado de producto obtenida correctamente",
                Data = productsDtos
            };
        }

        public async Task<ResponseDto<List<ProductDto>>> GetProductsListAsync()
        {
                var productsEntity = await _context.Products
                .Include(p => p.Category).ToListAsync(); // aqui el include es para incluir el tipo de categoria 


                var productsDtos = _mapper.Map<List<ProductDto>>(productsEntity);

                return new ResponseDto<List<ProductDto>>
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Listado de producto obtenida correctamente",
                    Data = productsDtos
                };
        }
        public async Task<ResponseDto<ProductDto>> GetProductByIdAsync(Guid id)
        {
            // aqui lo miusmos , fue en el mapeo el royo
            var productEntity = await _context.Products.Include(product => product.Category).FirstOrDefaultAsync(p => p.Id == id);
            if (productEntity == null)
            {
                return new ResponseDto<ProductDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el producto",
                };
            }

            var productDto = _mapper.Map<ProductDto>(productEntity);

            return new ResponseDto<ProductDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Producto encontrado",
                Data = productDto
            };
        }
        public async Task<ResponseDto<ProductDto>> CreateProductAsync(ProductCreateDto dto)
        {
            var CategoryProduct = await _context.CategoryProducts.FirstOrDefaultAsync(c => c.Id == dto.CategoryId);

            if (CategoryProduct == null) 
            {
                return new ResponseDto<ProductDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "La categoría de producto especificada no existe.",
                };
            }

           var productEntity = _mapper.Map<ProductEntity>(dto);
            _context.Products.Add(productEntity); // se genera el ID
            await _context.SaveChangesAsync();
            var productDto = _mapper.Map<ProductDto>(productEntity);
            return new ResponseDto<ProductDto>
            {
                StatusCode = 201,
                Status = true,
                Message = "Producto creado correctamente",
                Data = productDto
            };

        }
        public async Task<ResponseDto<ProductDto>> EditProductAsync(ProductEditDto dto, Guid id)
        {
            var productEntity = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            
            if (productEntity == null)
            {
                return new ResponseDto<ProductDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el producto",
                };
            }

            var CategoryProduct = await _context.CategoryProducts.FirstOrDefaultAsync(c => c.Id == dto.CategoryId);
            if (CategoryProduct == null)
            {
                return new ResponseDto<ProductDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "La categoría de producto especificada no existe.",
                };
            }

            _mapper.Map<ProductEditDto, ProductEntity>(dto, productEntity);
            _context.Products.Update(productEntity);
            await _context.SaveChangesAsync();

            var productDto = _mapper.Map<ProductDto>(productEntity);

            return new ResponseDto<ProductDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Producto modificado correctamente.",
                Data = productDto
            };
        }
        public  async Task<ResponseDto<ProductDto>> DeleteProductAsync(Guid id)
        {
            var productEntity = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (productEntity is null)
            {
                return new ResponseDto<ProductDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el producto.",
                };
            }

            _context.Products.Remove(productEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<ProductDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Producto eliminado correctamente.",

            };
        }
    }
}
