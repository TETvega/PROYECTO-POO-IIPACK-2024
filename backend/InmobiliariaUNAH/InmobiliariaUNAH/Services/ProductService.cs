using AutoMapper;
using InmobiliariaUNAH.Database;
using InmobiliariaUNAH.Database.Entities;
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
        public async Task<ResponseDto<List<NoteDt>>> GetProductsListAsync()
        {
                var productsEntity = await _context.Products
                .Include(p => p.Category).ToListAsync(); // aqui el include es para incluir el tipo de categoria 


                var productsDtos = _mapper.Map<List<NoteDt>>(productsEntity);

                return new ResponseDto<List<NoteDt>>
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Listado de producto obtenida correctamente",
                    Data = productsDtos
                };
        }
        public async Task<ResponseDto<NoteDt>> GetProductByIdAsync(Guid id)
        {
            // aqui lo miusmos , fue en el mapeo el royo
            var productEntity = await _context.Products.Include(product => product.Category).FirstOrDefaultAsync(p => p.Id == id);
            if (productEntity == null)
            {
                return new ResponseDto<NoteDt>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el producto",
                };
            }

            var productDto = _mapper.Map<NoteDt>(productEntity);

            return new ResponseDto<NoteDt>
            {
                StatusCode = 200,
                Status = true,
                Message = "Producto encontrado",
                Data = productDto
            };
        }
        public async Task<ResponseDto<NoteDt>> CreateProductAsync(ProductCreateDto dto)
        {
           var productEntity = _mapper.Map<ProductEntity>(dto);
            _context.Products.Add(productEntity); // se genera el ID
            await _context.SaveChangesAsync();
            var productDto = _mapper.Map<NoteDt>(productEntity);
            return new ResponseDto<NoteDt>
            {
                StatusCode = 201,
                Status = true,
                Message = "Producto creado correctamente",
                Data = productDto
            };

        }
        public async Task<ResponseDto<NoteDt>> EditProductAsync(ProductEditDto dto, Guid id)
        {
            var productEntity = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            
            if (productEntity == null)
            {
                return new ResponseDto<NoteDt>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el producto",
                };
            }

            _mapper.Map<ProductEditDto, ProductEntity>(dto, productEntity);
            _context.Products.Update(productEntity);
            await _context.SaveChangesAsync();

            var productDto = _mapper.Map<NoteDt>(productEntity);

            return new ResponseDto<NoteDt>
            {
                StatusCode = 200,
                Status = true,
                Message = "Producto modificado correctamente.",
                Data = productDto
            };
        }
        public  async Task<ResponseDto<NoteDt>> DeleteProductAsync(Guid id)
        {
            var productEntity = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (productEntity is null)
            {
                return new ResponseDto<NoteDt>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el registro",
                };
            }

            _context.Products.Remove(productEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<NoteDt>
            {
                StatusCode = 200,
                Status = true,
                Message = "Producto eliminado correctamente.",

            };
        }
    }
}
