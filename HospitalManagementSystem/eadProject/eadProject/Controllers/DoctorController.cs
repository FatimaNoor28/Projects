using eadProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace eadProject.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorRepo docRepo;

        public DoctorController()
        {
            docRepo = new DoctorRepository();
        }
        public IActionResult Index()
        {
            return View("DoctorSignUp");
        }
        [HttpPost]
        public IActionResult DoctorSignUp(string CNIC, string name, int appointments, string password)
        {
            //DoctorRepository dr = new DoctorRepository();
            if (docRepo.SignUpDoctor(CNIC, name, appointments, password))
            {
                ViewData["Msg"] = "You are Signed Up Successfully,LogIn to continue";
                return View("Login");
            }
            return View("UnsuccessfulSignUp");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public IActionResult Login(string CNIC, string password)
        {
            //DoctorRepository dr = new DoctorRepository();

            if (docRepo.Authenticate(CNIC, password))
            {
                Doctor d = docRepo.findDoctor(CNIC, password);
                List<Appointment> appointments = docRepo.findAppointments(d.Name);

                HttpContext.Response.Cookies.Append("Cookie", d.DoctorId.ToString());
                HttpContext.Response.Cookies.Append("UserType", "Doctor");
                ViewData["DoctorUserName"] = d.Name;

                return View("Index", appointments);
            }
            else return View("LoginUnsuccessful");
        }

    }
}
