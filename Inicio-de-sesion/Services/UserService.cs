
using Inicio_de_sesion.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTOs;
using WebAPI.Services;

// Define el namespace para los servicios de usuario
namespace Inicio_de_sesion.Services
{
    // Implementación del servicio de usuarios que implementa la interfaz IUserService
    public class UserService : IUserService
    {
        // Campo privado para el contexto de la base de datos
        private readonly UserContext _context;

        // Constructor que inyecta el contexto de la base de datos
        public UserService(UserContext context)
        {
            _context = context;
        }

        // Método para obtener todos los usuarios de forma asíncrona
        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            // Selecciona y convierte los usuarios a UserDto y los devuelve como una lista asíncrona
            return await _context.Users
                .Select(u => new UserDto { Id = u.Id, Name = u.Name, Email = u.Email, Phone = u.Phone })
                .ToListAsync();
        }

        // Método para obtener un usuario por su ID de forma asíncrona
        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            // Busca el usuario por su ID en la base de datos
            var user = await _context.Users.FindAsync(id);
            // Si no se encuentra el usuario, devuelve null
            if (user == null) return null;

            // Si se encuentra el usuario, lo convierte a UserDto y lo devuelve
            return new UserDto { Id = user.Id, Name = user.Name, Email = user.Email, Phone = user.Phone };
        }

        // Método para crear un nuevo usuario de forma asíncrona
        public async Task<UserDto> CreateUserAsync(UserInsertDto userInsertDto)
        {
            // Crea una nueva entidad User a partir del DTO UserInsertDto
            var user = new User
            {
                Name = userInsertDto.Name,
                Email = userInsertDto.Email,
                Password = userInsertDto.Password,
                Phone = userInsertDto.Phone
            };

            // Agrega el nuevo usuario al contexto de la base de datos
            _context.Users.Add(user);
            // Guarda los cambios en la base de datos de forma asíncrona
            await _context.SaveChangesAsync();

            // Convierte el usuario creado a UserDto y lo devuelve
            return new UserDto { Id = user.Id, Name = user.Name, Email = user.Email, Phone = user.Phone };
        }

        // Método para actualizar un usuario existente de forma asíncrona
        public async Task<bool> UpdateUserAsync(int id, UserUpdateDto userUpdateDto)
        {
            // Busca el usuario por su ID en la base de datos
            var user = await _context.Users.FindAsync(id);
            // Si no se encuentra el usuario, devuelve false
            if (user == null) return false;

            // Actualiza las propiedades del usuario con los datos del DTO
            user.Name = userUpdateDto.Name;
            user.Email = userUpdateDto.Email;
            user.Password = userUpdateDto.Password;
            user.Phone = userUpdateDto.Phone;

            // Marca la entidad como modificada en el contexto de la base de datos
            _context.Entry(user).State = EntityState.Modified;
            // Guarda los cambios en la base de datos de forma asíncrona
            await _context.SaveChangesAsync();

            // Devuelve true indicando que la actualización fue exitosa
            return true;
        }

        // Método para eliminar un usuario por su ID de forma asíncrona
        public async Task<bool> DeleteUserAsync(int id)
        {
            // Busca el usuario por su ID en la base de datos
            var user = await _context.Users.FindAsync(id);
            // Si no se encuentra el usuario, devuelve false
            if (user == null) return false;

            // Elimina el usuario del contexto de la base de datos
            _context.Users.Remove(user);
            // Guarda los cambios en la base de datos de forma asíncrona
            await _context.SaveChangesAsync();

            // Devuelve true indicando que la eliminación fue exitosa
            return true;
        }
    }
}
