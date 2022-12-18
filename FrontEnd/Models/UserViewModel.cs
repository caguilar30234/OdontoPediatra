using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class UserViewModel
    {
        [Key]
        public string Id { get; set; } = null!;
        [Required(ErrorMessage ="Ingrese su número de identificación")]
        [Display(Name = "ID/Cédula")]
        public string Identification { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese su nombre")]
        [Display(Name = "Nombre")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese su Apellido(s)")]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = "Se requiere un nombre de usuario")]
        [Display(Name = "Username")]
        public string Username { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese su email")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Ingrese su contraseña")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [PasswordPropertyText]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Ingrese su número de teléfono")]
        [Display(Name = "Teléfono")]
        [Phone]
        public string? PhoneNumber { get; set; }




    }
}
