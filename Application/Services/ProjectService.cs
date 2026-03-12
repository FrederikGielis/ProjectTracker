using ProjectTracker.Application.Abstractions;
using ProjectTracker.Domain.Entities;

namespace ProjectTracker.Application.Services;

public class ProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUserRepository _userRepository;

    public ProjectService(IProjectRepository projectRepository, IUserRepository userRepository)
    {
        _projectRepository = projectRepository;
        _userRepository = userRepository;
    }

    public List<ProjectItem> GetProjects(decimal? maxBudget = null)
    {
        var projects = maxBudget.HasValue
            ? _projectRepository.GetByMaxBudget(maxBudget.Value)
            : _projectRepository.GetAll();
        return projects.OrderByDescending(x => x.CreatedAt).ToList();
    }

    public decimal GetTotalBudget(decimal? maxBudget = null)
    {
        var projects = maxBudget.HasValue
            ? _projectRepository.GetByMaxBudget(maxBudget.Value)
            : _projectRepository.GetAll();
        return projects.Sum(p => p.Budget);
    }

    public List<AppUser> GetUsers()
    {
        return _userRepository.GetAll();
    }

    public ValidationResult AddProject(string name, string description, int ownerUserId, decimal budget)
    {
        var result = new ValidationResult();

        if (string.IsNullOrWhiteSpace(name))
        {
            result.AddError("Name", "Project name is required.");
        }
        else if (name.Trim().Length < 3)
        {
            result.AddError("Name", "Project name must be at least 3 characters.");
        }

        if (ownerUserId <= 0)
        {
            result.AddError("OwnerUserId", "Owner is required.");
        }

        if (budget <= 0)
        {
            result.AddError("Budget", "Budget is required and must be greater than zero.");
        }

        if (!result.IsValid)
        {
            return result;
        }

        var users = _userRepository.GetAll();
        var owner = users.FirstOrDefault(x => x.Id == ownerUserId);

        if (owner == null)
        {
            result.AddError("OwnerUserId", "Owner was not found.");
            return result;
        }

        var existing = _projectRepository
            .GetAll()
            .FirstOrDefault(x => x.Name.ToLower() == name.ToLower());

        if (existing != null)
        {
            result.AddError("Name", "A project with this name already exists.");
            return result;
        }

        var project = new ProjectItem
        {
            Name = name,
            Description = description,
            OwnerUserId = ownerUserId,
            Budget = budget,
            IsArchived = false
        };

        _projectRepository.Add(project);
        return result;
    }

    public void DeleteProject(int id)
    {
        _projectRepository.Delete(id);
    }
}
