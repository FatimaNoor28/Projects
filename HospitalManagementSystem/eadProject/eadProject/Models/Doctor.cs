using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eadProject.Models;


    public partial class Doctor : FullAudinModel
{
    public int DoctorId { get; set; }
    [Required(ErrorMessage = "Please enter CNIC")]
    [StringLength(15)]
    [MinLength(15)]
    public string? CNIC { get; set; }
    [Required(ErrorMessage = "Please enter password")]
    [MinLength(8)]
    public string? Password { get; set; }
    [Required(ErrorMessage = "Please enter name")]
    [StringLength(50)]
    public string? Name { get; set; }
    //[Required(ErrorMessage = "Please enter appointment ID")]
    public int? CurrentAppointments { get; set; }
    [Required(ErrorMessage = "Please enter appointment limit")]
    public int? ApointmentLimitPerDay { get; set; }
    //public ICollection<Appointment>? appointment { get; set; }
}
