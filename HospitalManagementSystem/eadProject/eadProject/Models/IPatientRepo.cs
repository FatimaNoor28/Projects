namespace eadProject.Models
{
    public interface IPatientRepo
    {
        public bool Authenticate(string username, string password);

        public int find_Patient(string username, string password);

        public string find_PatientName(string username, string password);

        public bool SignUpPatient(string CNIC, string username, string password);

        public List<Patient> GetAllAppointments(string username);


    }
}