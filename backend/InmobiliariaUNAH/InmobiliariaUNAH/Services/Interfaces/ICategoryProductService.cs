using InmobiliariaUNAH.Dtos.CategoriesProduct;
using InmobiliariaUNAH.Dtos.common;
using InmobiliariaUNAH.Dtos.Products;
using Microsoft.AspNetCore.Mvc;

namespace InmobiliariaUNAH.Services.Interfaces
{
    public interface ICategoryProductService
    {
        Task<ResponseDto<CategoryProductDto>> CreateCategoryProductAsync(CategoryProductCreateDto dto);
        Task<ResponseDto<CategoryProductDto>> DeleteCategoryProductAsync(Guid id);
        Task<ResponseDto<CategoryProductDto>> EditCategoryProductAsync(CategoryProductEditDto dto, Guid id);
        Task<ResponseDto<List<CategoryProductDto>>> GetCategoriesProductListAsync();
        Task<ResponseDto<CategoryProductDto>> GetCategoryProductAsync(Guid id);

        
    }
}
