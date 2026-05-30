using GymProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymProject.Controllers;

public class ProductsController: Controller
{
    
    public IActionResult Index()
    {
        List<Product> products = new()
        {
            new Product { Id = 1, Name = "Adjustable Dumbbells" },
            new Product { Id = 2, Name = "Yoga Mat" },
            new Product { Id = 3, Name = "Treadmill" },
            new Product { Id = 4, Name = "Resistance Bands Set" },
            new Product { Id = 5, Name = "Olympic Barbell" }
        };
        
        return View(products); // Views/Products/Index.cshtml
    }   
}