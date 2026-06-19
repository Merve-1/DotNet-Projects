using GymProject.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymProject.Controllers;

public class PlansController : Controller
{
    public JymDbContext Context = new JymDbContext();
    public async Task<IActionResult> Index()
    {
        var plans = await Context.Plans.ToListAsync();
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
        var plan = await Context.Plans.FirstOrDefaultAsync(p => p.Id == id);

        if (plan is null)
        {
            return RedirectToAction(nameof(Index)); //return 302 location header
        }
        return View(plan); //return view/plans/details.html
    }
}