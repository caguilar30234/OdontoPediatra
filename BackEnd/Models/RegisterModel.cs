using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BackEnd.Models
{ 
    public class RegisterModel
    {
        [Required(ErrorMessage = "Debe proporcionar un número de identificación")]
        [Display(Name = "Dimex / Cédula")]
        public string Identification { get; set; }

        [Required(ErrorMessage = "Debe escribir un nombre")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe escribir un apellido")]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Escriba un email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Se requiere un nombre de usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Debe de proporcionar un número de teléfono")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
