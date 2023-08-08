using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyWithValidations.Models;

namespace DojoSurveyWithValidations.Controllers;

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
        return View("index"); //<--- "index" is the index.cshtml file
    }

    [HttpPost("process")]
    public IActionResult Process(StudentData ShowStudent)
    {

        ViewBag.Name = ShowStudent.Name;
        ViewBag.Location = ShowStudent.Location;
        ViewBag.Language = ShowStudent.Language;
        ViewBag.Comment= ShowStudent.Comment;

        // AllStudents.Add(ShowStudent);

        // To return a view or a redirect
        return View("display");
    }

    // [HttpGet("results")]
    // public ViewResult Results()
    // {
    //     ViewBag.Name = TempData["Name"];
    //     return View("display", AllStudents); //<--- (Name of file to view, calling AllStudents)
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
