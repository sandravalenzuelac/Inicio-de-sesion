using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Services;

// Define el namespace del controlador
namespace WebAPI.Controllers
{
    // Configura la ruta base para las solicitudes HTTP a este controlador
    [Route("api/[controller]")]
    // Indica que este controlador responde a solicitudes de API (no vistas)
    [ApiController]
    public class UserController : ControllerBase
    {
        // Declaración de una variable privada para el servicio de usuarios
        private IUserService _userService;

        // Constructor que inyecta el servicio de usuarios en el controlador
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Acción HTTP GET para obtener todos los usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            // Llama al servicio para obtener la lista de usuarios
            var users = await _userService.GetUsersAsync();
            // Devuelve un resultado OK (200) con la lista de usuarios
            return Ok(users);
        }

        // Acción HTTP GET para obtener un usuario por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            // Llama al servicio para obtener un usuario específico por su ID
            var user = await _userService.GetUserByIdAsync(id);
            // Si el usuario no se encuentra, devuelve un resultado NotFound (404)
            if (user == null) return NotFound();

            // Si el usuario se encuentra, devuelve un resultado OK (200) con el usuario
            return Ok(user);
        }

        // Acción HTTP POST para crear un nuevo usuario
        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser(UserInsertDto userInsertDto)
        {
            // Llama al servicio para crear un nuevo usuario con los datos proporcionados
            var user = await _userService.CreateUserAsync(userInsertDto);
            // Devuelve un resultado Created (201) con la ruta para obtener el nuevo usuario y el usuario creado
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // Acción HTTP PUT para actualizar un usuario existente
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserUpdateDto userUpdateDto)
        {
            // Llama al servicio para actualizar el usuario con el ID y datos proporcionados
            var success = await _userService.UpdateUserAsync(id, userUpdateDto);
            // Si la actualización falla (usuario no encontrado), devuelve un resultado NotFound (404)
            if (!success) return NotFound();

            // Si la actualización es exitosa, devuelve un resultado NoContent (204)
            return NoContent();
        }

        // Acción HTTP DELETE para eliminar un usuario por su ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            // Llama al servicio para eliminar el usuario con el ID proporcionado
            var success = await _userService.DeleteUserAsync(id);
            // Si la eliminación falla (usuario no encontrado), devuelve un resultado NotFound (404)
            if (!success) return NotFound();

            // Si la eliminación es exitosa, devuelve un resultado NoContent (204)
            return NoContent();
        }
    }
}
