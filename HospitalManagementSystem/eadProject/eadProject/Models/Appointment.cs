using System.ComponentModel.DataAnnotations;

namespace eadProject.Models;


    public partial class Appointment
    {
    public int AppointmentId { get; set; }
    [Required(ErrorMessage = "Please enter doctor name")]
    [StringLength(500)]
    public string? DoctorName { get; set; }
    [Required(ErrorMessage = "Please enter patient id")]
    public int? PatientId { get; set; }
    
    public int? Date { get; set; }
    
    public int? Month { get; set; }
    [DataType(DataType.Time)]
    public string? time { get; set; }
    [Phone]
    [Required(ErrorMessage = "Please enter phone number")]
    public string? PhoneNo { get; set; }

    public Patient? patient { get; set; }

    //public Doctor? doctor { set; get; } 

    }

