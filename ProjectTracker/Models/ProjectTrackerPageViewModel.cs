using ProjectTracker.Domain.Entities;

namespace ProjectTracker.Models;

public class ProjectTrackerPageViewModel
{
    public List<ProjectItem> Projects { get; set; } = [];
    public List<AppUser> Users { get; set; } = [];
    public decimal? MaxBudgetFilter { get; set; }
    public decimal TotalBudget { get; set; }
}
