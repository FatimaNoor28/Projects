namespace eadProject.Models
{
    public interface IAppointmentRepo
    {
        public List<Appointment> GetAppointments(string CNIC);

        public List<Appointment> GetAppointmentWithId(int id);

        public bool MakeAppointment(int id, string name, string phone, int date, int month, string doctor);

        public bool IsDateValid(int year, int month, int day);
    }
}
