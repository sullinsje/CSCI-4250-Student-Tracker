using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudentTrackerMvc.Models;

namespace StudentTrackerMvc.Controllers;

public class TeacherController : Controller
{
    private readonly ILogger<TeacherController> _logger;

    public StudentController(ILogger<TeacherController> logger)
    {
        _logger = logger;
    }

    public IActionResult Teacher()
    {
        return View();
    }

    public IActionResult StudentList()
    {
        //var data = _dbContext.AttendanceRecords.ToList();
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}