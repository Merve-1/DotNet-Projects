using Jym.DataAccess.Data.Contexts;
using Jym.DataAccess.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jym.Controllers;

public class PlansController(IPlanRepository planRepo) : Controller
{
    //public IPlanRepository planRepo = new PlanRepository();
    public async Task<IActionResult> Index()
    {
        var plans = await planRepo.GetAllAsync();
        return View(plans);
    }

    public async Task<IActionResult> Details(int id) {
        if (id <= 0)
        {
            //Not found page is not the best solution,
            //you can return the user to the page before
            //the redirection or use not found in url as the following
            return NotFound();
        }

        var plan = await planRepo.GetByIdAsync(id);

        if (plan is null)
        {
            return RedirectToAction(nameof(Index)); //return 302 location header
        }
        return View(plan); //return view/plans/details.html
    }
}
/*
public class OrderService
{
    // Dependency Injection: Receive Objects 
    //  1. Constructors 
    //  2. Method 
    private IPayment _payment;
    // order received through the constructor 
    public OrderService(IPayment payment)
    {
        _payment = payment;
    }
    //IPayment instaPay;
    public void MakeOrder()
    {
        // order logic
        _payment.Pay();
        // Issue: change payment method the implementation will be changed 
        //   this break teh OCP: open for extensions but closed for modifications
        // DIP: High level modules should not depend on low level modules, 
        //   both depends on abstraction  
        // High Level: Order service 
        // Low Level: Instapay (abstraction)
        
    }
}

public interface IPayment
{
    public void Pay();
}
public class InstaPay: IPayment
{
    public void Pay()
    {
        Console.WriteLine("Pay with instapay");
    }
}*/