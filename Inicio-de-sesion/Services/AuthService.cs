using Inicio_de_sesion.DTOs;
using Inicio_de_sesion.Models;
using Microsoft.EntityFrameworkCore;

namespace Inicio_de_sesion.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserContext _context;

        public AuthService(UserContext context)
        {
            _context = context;
        }

        public async Task<AuthenticatedUserDto> AuthenticateAsync(UserLoginDto userLoginDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == userLoginDto.Username && u.Password == userLoginDto.Password);

            if (user == null)
                return null;

            return new AuthenticatedUserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public async Task<AuthenticatedUserDto> RegisterAsync(UserRegisterDto userRegisterDto)
        {
            // Verifica si el usuario o email ya existe
            if (await _context.Users.AnyAsync(u => u.Username == userRegisterDto.Username || u.Email == userRegisterDto.Email))
            {
                return null;
            }

            var user = new User
            {
                Username = userRegisterDto.Username,
                Name = userRegisterDto.Name,
                Email = userRegisterDto.Email,
                Password = userRegisterDto.Password,
                Phone = userRegisterDto.Phone
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new AuthenticatedUserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }
    }
    
}
