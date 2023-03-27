namespace eadProject.Models
{
    public interface IDoctorRepo
    {
        public bool Authenticate(string CNIC, string password);

        public bool SignUpDoctor(string CNIC, string username, int appointments, string password);

        public Doctor findDoctor(string cnic, string password);

        public List<Appointment> findAppointments(string name);
    }
}
