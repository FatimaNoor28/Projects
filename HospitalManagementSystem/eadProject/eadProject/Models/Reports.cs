using System.ComponentModel.DataAnnotations;

namespace eadProject.Models
{
    public class Reports
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter image")]
        public string? link { get; set; }
        [Required(ErrorMessage = "Please enter patient ID")]
        public int? PatientId { get; set; }
        [Required]
        public Patient patient { get; set; }

    }
}
