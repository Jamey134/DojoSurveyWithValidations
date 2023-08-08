using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyWithValidations.Models;
using System.Collections.Generic;

namespace DojoSurveyWithValidations.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static List<StudentData> AllStudents = new List<StudentData>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public ViewResult Index()
        {
            return View("index");
        }

        [HttpPost("process")]
        public IActionResult Process(StudentData ShowStudent) //<--- (Model, Data)
        {
            // The if statement triggers if our model passed its validation checks
            if (ModelState.IsValid)
            {
                // Process and add the student data
                // AllStudents.Add(ShowStudent);
                // Do something! Maybe insert into a database or log data to the console  
                Console.WriteLine(ShowStudent.Name);
                Console.WriteLine(ShowStudent.Location);
                Console.WriteLine(ShowStudent.Language);
                Console.WriteLine(ShowStudent.Comment);
                // Then we will redirect to a new page        
                return View("display", ShowStudent);
            }
            else
            {
                // Oh no! We need to return a ViewResponse to preserve the ModelState and the errors it now contains! 
                // Make sure you return the View that contains the form!
                // Also, pass the invalid model back to the view so validation errors can be displayed.
                return View("index");
            }
            // ViewBag.Location = ShowStudent.Location;
            // ViewBag.Language = ShowStudent.Language;
            // ViewBag.Comment = ShowStudent.Comment;
        }

        [HttpGet("display")]
        public IActionResult Display()
        {
            // ViewBag.Name = ShowStudent.Name;
            return View("display", AllStudents);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
