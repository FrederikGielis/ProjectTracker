using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Application;
using ProjectTracker.Application.Services;
using ProjectTracker.Models;

namespace ProjectTracker.Controllers;

public class ProjectsController : Controller
{
    private readonly ProjectService _projectService;

    public ProjectsController(ProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public IActionResult Index(decimal? maxBudget)
    {
        var vm = new ProjectTrackerPageViewModel
        {
            Projects = _projectService.GetProjects(maxBudget),
            Users = _projectService.GetUsers(),
            MaxBudgetFilter = maxBudget,
            TotalBudget = _projectService.GetTotalBudget(maxBudget)
        };

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(CreateProjectInputModel input)
    {
        ValidationResult? result = _projectService.AddProject(input.Name, input.Description ?? string.Empty, input.OwnerUserId, input.Budget);

        if (!result.IsValid)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Key, error.Value);
            }

            var vm = new ProjectTrackerPageViewModel
            {
                Projects = _projectService.GetProjects(),
                Users = _projectService.GetUsers()
            };

            return View(nameof(Index), vm);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        _projectService.DeleteProject(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Users()
    {
        var users = _projectService.GetUsers();
        return Json(users);
    }
}
