using InmobiliariaUNAH.Dtos.common;
using InmobiliariaUNAH.Dtos.Products;

namespace InmobiliariaUNAH.Services.Interfaces
{
    public interface IProductService
    {
        Task<ResponseDto<List<ProductDto>>> GetProductsListByCategoryIdAsync(Guid id);
        Task<ResponseDto<PaginationDto<List<ProductDto>>>> GetProductsListAsync(string searchTerm = "", int page = 1);
        Task<ResponseDto<ProductDto>> GetProductByIdAsync(Guid id);
        Task<ResponseDto<ProductDto>> CreateProductAsync(ProductCreateDto dto);
        Task<ResponseDto<ProductDto>> EditProductAsync(ProductEditDto dto, Guid id);
        Task<ResponseDto<ProductDto>> DeleteProductAsync(Guid id);
    }
}
