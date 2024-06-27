// Define el namespace para la clase UserUpdateDto
namespace WebAPI.DTOs
{
    // DTO para recibir datos al actualizar un usuario existente
    public class UserUpdateDto
    {
        // Identificador único del usuario (debe ser especificado para la actualización)
        public int Id { get; set; }
        // Nombre del usuario
        public string Name { get; set; }
        // Correo electrónico del usuario
        public string Email { get; set; }
        // Contraseña del usuario
        public string Password { get; set; }
        // Número de teléfono del usuario
        public string Phone { get; set; }
    }
}

