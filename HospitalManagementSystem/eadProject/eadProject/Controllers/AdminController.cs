using eadProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System.Diagnostics;

namespace eadProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger logger;
        private readonly IWebHostEnvironment Environment;
        private readonly IReportsRepo reportsRepo;
        private readonly IAdminRepo adRepo;
        public AdminController(IWebHostEnvironment environment,ILogger<AdminController> log )
        {
            logger = log;
            Environment = environment;
            reportsRepo = new ReportsRepository();
            adRepo = new AdminRepository();
        }

        public IActionResult Index()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];

                return View();
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
        }

        [HttpGet]
        public IActionResult SignUpAdmin()
        {
            return View("SignUpAdmin");
        }
        [HttpPost]
        public IActionResult SignUpAdmin(string CNIC, string Name, string password)
        {
            if (ModelState.IsValid)
            {
                //AdminRepository ar = new AdminRepository();
                if (adRepo.SignUpAdmin(CNIC, Name, password))
                {
                    ViewData["Msg"] = "You are Siggned Up Successfully,LogIn to continue";
                    return View("Login");
                }
            }
            return View("UnsuccessfulSignUp");
        }
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(string CNIC, string password)
        {
            if (ModelState.IsValid)
            {

                //AdminRepository ar = new AdminRepository();
                if (adRepo.Authenticate(CNIC, password))
                {
                    var a = adRepo.FindAdminId(CNIC, password);
                    var A_name = adRepo.find_AdminName(CNIC, password);
                    HttpContext.Response.Cookies.Append("Cookie", a.ToString());
                    HttpContext.Response.Cookies.Append("UserType", "Admin");
                    HttpContext.Response.Cookies.Append("AdminUserName", A_name);
                    ViewData["AdminUserName"] = A_name;

                    return View("Index");
                }
            }
            return View("UnsuccessfulLogin");
        }

        [HttpGet]
        public ViewResult AddPatient()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];

                return View("AddPatient");
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }

        }
        [HttpPost]
        public ViewResult AddPatient([FromForm] Patient p)
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
                {
                    ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];
                    PatientRepository pr = new PatientRepository();
                    if (pr.SignUpPatient(p.CNIC, p.Name, p.Password))
                        return View("Index");
                }
                else
                {
                    ViewData["Msg"] = "Login to Access this Page ,Error 404";
                    return View("Login");

                }
            }
            if (HttpContext.Request.Cookies.ContainsKey("Cookie"))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];
            }
            return View();            
        }
        [HttpGet]
        public ViewResult FindPatient()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];

                return View();
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
        }
        [HttpPost]
        public ViewResult FindPatient(int Id)
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
                {
                    ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];
                    //AdminRepository ar = new AdminRepository();
                    Patient p = adRepo.find_Patient(Id);
                    return View("DisplayPatient", p);
                }
                else
                {
                    ViewData["Msg"] = "Login to Access this Page ,Error 404";
                    return View("Login");
                }
            }
            if (HttpContext.Request.Cookies.ContainsKey("Cookie")) {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];
            }
            return View();
        }

        [HttpGet]
        public ViewResult DisplayPatient()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];

                return View();
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
        }
        [HttpGet]
        public ViewResult UpdatePatient()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];

                return View();
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }

        }

        //[Route("/Admin/UpdatePatient", Name = "update")]
        [HttpPost]
        public ViewResult UpdatePatient(int Id)
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                //AdminRepository ar = new AdminRepository();
                Patient p = adRepo.find_Patient(Id);
                return View("updateRecord", p);
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
        }

        public ViewResult updateRecord()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];

                return View();
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
        }
        //[Route("Speaker/{id:int}")]
        [HttpPost]
        public ViewResult updateRecord(int Id, string Name, string CNIC, string Password)
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
                {
                    //AdminRepository ar = new AdminRepository();
                    adRepo.updatePatient(Id, Name, CNIC, Password);
                    ViewData["Msg"] = "Patient ID " + Id + " has been updated...";
                    return View("Index", Id);
                }
                else
                {
                    ViewData["Msg"] = "Login to Access this Page ,Error 404";
                    return View("Login");
                }
            }
            return View();
            
        }
        [HttpGet]
        public ViewResult AssignRoom()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];
                return View("AssignRoom");
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }

        }
        [HttpPost]
        public ViewResult AssignRoom(int Id, int RoomNo)
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {


                return View();
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
        }
        [HttpGet]
        public ViewResult DeletePatient()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];
                return View();
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }

        }
        [HttpPost]
        public ViewResult DeletePatient(int Id)
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
                {
                    //AdminRepository ar = new AdminRepository();
                    Patient p = adRepo.find_Patient(Id);
                    adRepo.RemovePatient(Id);
                    if (adRepo.find_Patient(Id) == null)
                        return View("Index");
                }
                else
                {
                    ViewData["Msg"] = "Login to Access this Page ,Error 404";
                    return View("Login");
                }
                
            }
            return View();
        }

        [HttpGet]
        public ViewResult AllPatients()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];
                //AdminRepository ar = new AdminRepository();
                List<Patient> p = adRepo.GetAllPatients();
                return View(p);
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
        }

        [HttpGet]
        public ViewResult uploadPatientReport()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];
                return View();
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
        }

        [HttpPost]
        public ViewResult uploadPatientReport(List<IFormFile> postedFiles, int PatientId)
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
                {
                    //ReportsRepository repo = new ReportsRepository();
                    ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];
                    string wwwPath = this.Environment.WebRootPath;
                    string path = Path.Combine(wwwPath, "Uploads");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    foreach (var file in postedFiles)
                    {

                        var fileName = Path.GetFileName(file.FileName);
                        var pathWithFileName = Path.Combine(path, fileName);
                        using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                        {
                            if (!reportsRepo.AddReports(pathWithFileName, PatientId))       //function is called through IReportsRepo obj 
                            {
                                ViewData["Msg"] = "File Not Uploaded";
                                return View("Index");
                            }

                            file.CopyTo(stream);
                            ViewBag.Message = "file uploaded successfully";
                        }
                    }
                    return View("Index");
                }
            }
            ViewData["Msg"] = "Login to Access this Page ,Error 404";
            return View("Login");
            
            //return View();
        }
        public string CurrentAdmin()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                return HttpContext.Request.Cookies["AdminUserName"];
            }
            else return "No User found";

        }
    }
}
