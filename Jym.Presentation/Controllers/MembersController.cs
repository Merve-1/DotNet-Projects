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
            TempData["Error"] = "Cannot Create a Member";
            return View(model);
        }

        TempData["Success"] = "Member Created Successfully";

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id, CancellationToken ct)
    {
        var member = await members.GetDetailsAsync(id, ct);

        if (member == null)
        {
            return NotFound();
        }

        return View(member);
    }

    [HttpGet]
    public async Task<IActionResult> HealthRecord(int id, CancellationToken ct)
    {
        var healthRecord = await members.GetHealthRecordAsync(id, ct);

        if (healthRecord == null)
        {
            return NotFound();
        }

        return View(healthRecord);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id, CancellationToken ct)
    {
        var member = await members.GetForUpdateAsync(id, ct);

        if (member == null)
        {
            return NotFound();
        }

        return View(member);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromRoute] int id, EditMemberViewModel editMemberViewModel, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(editMemberViewModel);

        var result = await members.UpdateAsync(id, editMemberViewModel, ct);

        if (!result.IsSuccess)
        {
            ModelState.AddModelError(result.ErrorKey ?? string.Empty, result.Error!);
            TempData["Error"] = "Cannot Update a Member";
            return View(editMemberViewModel);
        }

        TempData["Success"] = "Member Updated Successfully";

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var member = await members.GetDetailsAsync(id, ct);

        if (member == null)
            return NotFound();

        ViewBag.Id = member.Id;

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken ct)
    {
        var result = await members.DeleteAsync(id, ct);

        if (!result.IsSuccess)
        {
            TempData["Error"] = "Cannot Delete a Member";
            ViewBag.Id = id;
            return View();
        }

        TempData["Success"] = "Member Deleted Successfully";

        return RedirectToAction(nameof(Index));
    }
}
