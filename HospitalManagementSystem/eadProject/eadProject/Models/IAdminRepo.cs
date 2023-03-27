namespace eadProject.Models
{
    public interface IAdminRepo
    {
        public bool Authenticate(string username, string password);

        public int FindAdminId(string username, string password);

        public string? find_AdminName(string username, string password);

        public bool SignUpAdmin(string CNIC, string Name, string password);

        public Patient? find_Patient(int id);

        public void RemovePatient(int id);

        public List<Patient> GetAllPatients();

        public bool updatePatient(int id, string name, string cnic, string passwoord);

    }
}
