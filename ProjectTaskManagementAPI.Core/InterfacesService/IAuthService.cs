using ProjectTaskManagementAPI.Core.Dtos;

namespace ProjectTaskManagementAPI.Core.InterfacesService
{
    public interface IAuthService
    {
        Task<AuthResponseDto> Register(RegisterDto dto);
        Task<AuthResponseDto?> Login(LoginDto dto);
    }
}
