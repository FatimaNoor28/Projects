using eadProject.Models;
using System.ComponentModel.DataAnnotations;

namespace eadProject.Models;


    public partial class Patient : FullAudinModel
{
    [Required(ErrorMessage ="please enter ID")]
    public int Id { get; set; }
    [Required(ErrorMessage = "Please enter CNIC")]
    [StringLength(15)]
    public string? CNIC { get; set; }
    [Required(ErrorMessage = "Please enter name")]
    [StringLength(50)]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Please enter password")]
    [MinLength(8)]
    public string? Password { get; set; }

    public ICollection<Reports>? reports { get; set; }

    public ICollection<Appointment>? appointments { get; set; }

}