using System.ComponentModel.DataAnnotations;


namespace FrontEnd.Models

{
    public class DoctorViewModel
    {
        [Key]
        public int DoctorId { get; set; }
  
        public string Identification { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

    }
}
