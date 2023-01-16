using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmpApp.Models;
using DAL;
using BOL;

namespace EmpApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Employee> emps = DBManager.GetAllEmployees();
        this.ViewData["emp"] = emps;
        return View();
    }

    public IActionResult Details(int id)
    {
        Employee emp = DBManager.GetEmployeeById(id);
        this.ViewData["emp"] = emp;

        return View();
    }

    public IActionResult Register()
    {
        Employee employee = new Employee();
        return View(employee);
    }

    // public IActionResult Privacy()
    // {
    //     return View();
    // }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
    [HttpPost]
    public IActionResult Register(Employee emp)
    {
        if (DBManager.Insert(emp))
        {
            return RedirectToAction("index");
        }
        return View();
    }
}
