using System.ComponentModel.DataAnnotations;


namespace BackEnd.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "El usuario es requerido")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es requerido")]
        public string Password { get; set; }
    }
}
