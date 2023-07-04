using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BrokerAppointements.Models;

namespace BrokerAppointements.Controllers;

public class HomeController : Controller
{
    
    public IActionResult Index()
    {
        return View();
    }
}