using System.Diagnostics;
using Jym.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Jym.Presentation.Controllers;

public class HomeController : Controller
{
    //why readonly to make sure it will never be converted to null 
    //private readonly IPayment payment;
    public IActionResult Index()
    {
        return View();
    }

  
}