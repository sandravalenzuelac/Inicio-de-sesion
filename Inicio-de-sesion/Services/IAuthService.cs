using Inicio_de_sesion.DTOs;
using Inicio_de_sesion.Models;
using Microsoft.EntityFrameworkCore;

namespace Inicio_de_sesion.Services
{
    public interface IAuthService
    {
        Task<AuthenticatedUserDto> AuthenticateAsync(UserLoginDto userLoginDto);
        Task<AuthenticatedUserDto> RegisterAsync(UserRegisterDto userRegisterDto);
    }
}

