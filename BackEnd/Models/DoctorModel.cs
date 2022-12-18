using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class DoctorModel
    {
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "Debe ingresar un numero de identificación")]
        public string Identification { get; set; } = null!;
        [Required(ErrorMessage = "Debe ingresar su nombre")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Debe ingresar su apellido")]
        public string LastName { get; set; } = null!;
    }
}
