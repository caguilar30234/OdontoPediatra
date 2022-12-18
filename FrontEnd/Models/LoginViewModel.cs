using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El usuario es requerido")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es requerido")]
        public string Password { get; set; }
    }
}
