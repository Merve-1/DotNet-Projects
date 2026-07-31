using Jym.BusinessLogic.Services;
using Jym.BusinessLogic.ViewModels.Members;
using Microsoft.AspNetCore.Mvc;

namespace Jym.Controllers;

public class MembersController(IMemberService members) : Controller
{
    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var items = await members.GetAllAsync(ct);
        return View(items);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateMemberViewModel model, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await members.CreateAsync(model, ct);

        if (!result.IsSuccess)
        {
            ModelState.AddModelError(result.ErrorKey ?? string.Empty, result.Error!);
            return View(model);
        }

        return RedirectToAction(nameof(Index));
    }
}