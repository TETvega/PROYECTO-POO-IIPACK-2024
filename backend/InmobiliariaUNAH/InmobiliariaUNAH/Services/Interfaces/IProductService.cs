using InmobiliariaUNAH.Dtos.common;
using InmobiliariaUNAH.Dtos.Products;

namespace InmobiliariaUNAH.Services.Interfaces
{
    public interface IProductService
    {
        
        Task<ResponseDto<List<NoteDt>>> GetProductsListAsync();
        Task<ResponseDto<NoteDt>> GetProductByIdAsync(Guid id);
        Task<ResponseDto<NoteDt>> CreateProductAsync(ProductCreateDto dto);
        Task<ResponseDto<NoteDt>> EditProductAsync(ProductEditDto dto, Guid id);
        Task<ResponseDto<NoteDt>> DeleteProductAsync(Guid id);
    }
}
