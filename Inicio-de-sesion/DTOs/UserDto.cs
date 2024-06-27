// Define el namespace para la clase UserDto
namespace WebAPI.DTOs
{
    // DTO para representar un usuario al devolver datos al cliente
    public class UserDto
    {
        // Identificador único del usuario
        public int Id { get; set; }
        // Nombre del usuario
        public string Name { get; set; }
        // Correo electrónico del usuario
        public string Email { get; set; }
        // Número de teléfono del usuario
        public string Phone { get; set; }
    }
}
