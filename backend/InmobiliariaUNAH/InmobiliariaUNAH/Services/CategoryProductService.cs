using AutoMapper;
using InmobiliariaUNAH.Database;
using InmobiliariaUNAH.Database.Entities;
using InmobiliariaUNAH.Dtos.CategoriesProduct;
using InmobiliariaUNAH.Dtos.common;
using InmobiliariaUNAH.Dtos.Products;
using InmobiliariaUNAH.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaUNAH.Services
{
    public class CategoryProductService : ICategoryProductService
    {
        private readonly InmobiliariaUNAHContext _context;
        private readonly IMapper _mapper;

        public CategoryProductService(InmobiliariaUNAHContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<CategoryProductDto>>> GetCategoriesProductListAsync()
        {
            var categoriesproductsEntity = await _context.CategoryProducts.ToArrayAsync();


            var categoriesproductsDtos = _mapper.Map<List<CategoryProductDto>>(categoriesproductsEntity);

            return new ResponseDto<List<CategoryProductDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Listado de categorias de producto obtenida correctamente.",
                Data = categoriesproductsDtos
            };
        }

        public async Task<ResponseDto<CategoryProductDto>> GetCategoryProductAsync(Guid id)
        {
            var categoryProductEntity = await _context.CategoryProducts.FirstOrDefaultAsync(p => p.Id == id);
            if (categoryProductEntity == null)
            {
                return new ResponseDto<CategoryProductDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el producto",
                };
            }

            var categoryProductDto = _mapper.Map<CategoryProductDto>(categoryProductEntity);

            return new ResponseDto<CategoryProductDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Listado de producto obtenida correctamente",
                Data = categoryProductDto
            };
        }
        public async Task<ResponseDto<CategoryProductDto>> CreateCategoryProductAsync(CategoryProductCreateDto dto)
        {
           
            var categoryProductEntity = _mapper.Map<CategoryProductEntity>(dto);
            _context.CategoryProducts.Add(categoryProductEntity);
            await _context.SaveChangesAsync();

            var categoryProductDto = _mapper.Map<CategoryProductDto>(categoryProductEntity);

            return new ResponseDto<CategoryProductDto>
            {
                StatusCode = 201,
                Status = true,
                Message = "Producto creado correctamente.",
                Data = categoryProductDto,
            };

        }

        public async Task<ResponseDto<CategoryProductDto>> EditCategoryProductAsync(CategoryProductEditDto dto, Guid id)
        {
            var categoryProductEntity = await _context.CategoryProducts.FirstOrDefaultAsync(c => c.Id == id);
            if (categoryProductEntity == null)
            {
                return new ResponseDto<CategoryProductDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el producto la categoría de producto especificada.",
                };
            }

            _mapper.Map<CategoryProductEditDto, CategoryProductEntity>(dto, categoryProductEntity);
            _context.CategoryProducts.Update(categoryProductEntity);
            await _context.SaveChangesAsync();

            var categoryProductDto = _mapper.Map<CategoryProductDto>(categoryProductEntity);

            return new ResponseDto<CategoryProductDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Categoría del Producto modificado correctamente.",
                Data = categoryProductDto
            };
        }
        public async Task<ResponseDto<CategoryProductDto>> DeleteCategoryProductAsync(Guid id)
        {
            var categoryProductEntity = await _context.CategoryProducts.FirstOrDefaultAsync(p => p.Id == id);

            if (categoryProductEntity is null)
            {
                return new ResponseDto<CategoryProductDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró la categoria del producto.",
                };
            }

            _context.CategoryProducts.Remove(categoryProductEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<CategoryProductDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Producto eliminado correctamente.",

            };
        }
}
}
