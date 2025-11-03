using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudentTrackerMvc.Models;

namespace StudentTrackerMvc.Controllers;

public class StudentController : Controller
{
    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger)
    {
        _logger = logger;
    }

    public IActionResult Student()
    {
        return View();
    }

    public IActionResult AttendanceHistory()
    {
        //var data = _dbContext.AttendanceRecords.ToList();
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Dashboard()
    {
        return View();
    }
    // Temporary authentication: User:12345 Pass: password
    [HttpPost]
        public IActionResult Login(string studentId, string password, bool remember)
        {
            
            if (string.IsNullOrEmpty(studentId) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Please enter both Student ID and password.";
                return View();
            }

            if (studentId == "12345" && password == "password")
            {
                return RedirectToAction("Dashboard", "Student");
            }
            else
            {
                ViewBag.Error = "Invalid Student ID or password.";
                return View();
            }
        }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}