using System;
using System.Collections.Generic;

namespace EAD_Project.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public string? DoctorName { get; set; }

    public int? PatientId { get; set; }

    public DateTime Date { get; set; }

    public string PatientCNIC { get; set; }

    public string? PhoneNo { get; set; }

    public string? Department { get; set; }

}
