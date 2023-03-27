namespace eadProject.Models
{
    public interface IReportsRepo
    {
        bool AddReports(string link, int PatientId);
    }
}
