using AutoMapper;
using InmobiliariaUNAH.Database;
using InmobiliariaUNAH.Database.Entities;
using InmobiliariaUNAH.Dtos.common;
using InmobiliariaUNAH.Dtos.Products;
using InmobiliariaUNAH.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace InmobiliariaUNAH.Services
{
    public class ProductService : IProductService
    {
        private readonly InmobiliariaUNAHContext _context;
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;
        private readonly int PAGE_SIZE;
        public ProductService(InmobiliariaUNAHContext context, ILogger<ProductService> logger, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            PAGE_SIZE = configuration.GetValue<int>("PageSize");
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
        public async Task<ResponseDto<PaginationDto<List<ProductDto>>>> GetProductsListAsync(string searchTerm = "",string category ="", int page = 1)
        {
            int startIndex = (page - 1) * PAGE_SIZE;
            // Tratar productEntityQuery como IQueryable<ProductEntity>. Pata evitar problemas de conflictos con el codigo que está en el proximo if
            IQueryable<ProductEntity> productEntityQuery = _context.Products.Include(p => p.Category);
            
            if (!string.IsNullOrEmpty(category))
            {
                productEntityQuery = productEntityQuery.Where(p => p.Category.Name == category );
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                productEntityQuery = productEntityQuery.Where(x => (x.Name + " " + x.Category.Name + " " + x.Description)
                    .ToLower().Contains(searchTerm.ToLower()));
            }
            if (!string.IsNullOrEmpty(searchTerm) && !string.IsNullOrEmpty(category))
            {
                productEntityQuery = productEntityQuery.Where(x => x.Category.Name == category &&
                          (x.Name + " " + x.Description).ToLower().Contains(searchTerm.ToLower()));

            }
            int totalProducts = await productEntityQuery.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalProducts / PAGE_SIZE);

            var productsEntity = await productEntityQuery
                .OrderBy(p => p.Name)
                .Skip(startIndex)
                .Take(PAGE_SIZE)
                .ToListAsync();
            
            var productsDtos = _mapper.Map<List<ProductDto>>(productsEntity);
  
            return new ResponseDto<PaginationDto<List<ProductDto>>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Listado de Productos Obtenida Correctamente",
                Data = new PaginationDto<List<ProductDto>>
                {
                    CurrentPage = page,
                    PageSize = PAGE_SIZE,
                    TotalItems = totalProducts,
                    TotalPages = totalPages,
                    Items = productsDtos,
                    HasPreviousPage = page > 1,
                    HasNextPage = page < totalPages,
                }
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
