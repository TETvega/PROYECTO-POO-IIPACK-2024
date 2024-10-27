using InmobiliariaUNAH.Dtos.Auth;
using InmobiliariaUNAH.Dtos.common;

namespace InmobiliariaUNAH.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseDto<LoginResponseDto>> LoginAsync(LoginDto dto);
    }
}
