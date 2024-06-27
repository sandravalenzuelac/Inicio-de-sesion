// Importa el namespace para la validación de datos
using System.ComponentModel.DataAnnotations;

// Define el namespace para la clase UserInsertDto
namespace WebAPI.DTOs
{
    // DTO para recibir datos al crear un nuevo usuario
    public class UserInsertDto
    {
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
