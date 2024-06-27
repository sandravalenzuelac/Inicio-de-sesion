// Importa el namespace para los Data Transfer Objects (DTOs)
using WebAPI.DTOs;

// Define el namespace para los servicios de la aplicación
namespace WebAPI.Services
{
    // Define una interfaz para el servicio de usuarios
    public interface IUserService
    {
        // Método para obtener todos los usuarios
        Task<IEnumerable<UserDto>> GetUsersAsync();
        // Método para obtener un usuario por su ID
        Task<UserDto> GetUserByIdAsync(int id);
        // Método para crear un nuevo usuario
        Task<UserDto> CreateUserAsync(UserInsertDto userInsertDto);
        // Método para actualizar un usuario existente
        Task<bool> UpdateUserAsync(int id, UserUpdateDto userUpdateDto);
        // Método para eliminar un usuario por su ID
        Task<bool> DeleteUserAsync(int id);
    }
}

