using ProjectTracker.Application.Abstractions;
using ProjectTracker.Domain.Entities;

namespace ProjectTracker.Infrastructure.Persistence;

public class InMemoryProjectRepository : IProjectRepository
{
    private static readonly List<ProjectItem> _projects =
    [
        new ProjectItem
        {
            Id = 1,
            Name = "Dunder Mifflin Website",
            Description = "New React and .NET website for Dunder Mifflin",
            OwnerUserId = 1,
            Budget = 12000,
            CreatedAt = DateTime.Now.AddDays(-8)
        },
        new ProjectItem
        {
            Id = 2,
            Name = "Wayne Enterprises",
            Description = "Move on premise ERP system to hybrid cloud",
            OwnerUserId = 2,
            Budget = 30000,
            CreatedAt = DateTime.Now.AddDays(-3)
        },
        new ProjectItem
        {
            Id = 3,
            Name = "Stark Industries",
            Description = "Personell management system for Stark Industries",
            OwnerUserId = 2,
            Budget = 46000,
            CreatedAt = DateTime.Now.AddDays(-19)
        }
    ];

    public List<ProjectItem> GetAll()
    {
        return _projects;
    }

    public List<ProjectItem> GetByMaxBudget(decimal maxBudget)
    {
        var result = new List<ProjectItem>();
        for (int i = 0; i < _projects.Count(); i++)
        {
            var p = _projects.ElementAt(i);
            if (!(p.Budget > maxBudget) == true)
            {
                var copy = new ProjectItem();
                copy.Id = p.Id;
                copy.Name = p.Name;
                copy.Description = p.Description;
                copy.OwnerUserId = p.OwnerUserId;
                copy.Budget = p.Budget;
                copy.CreatedAt = p.CreatedAt;
                copy.IsArchived = p.IsArchived;
                result.Add(copy);
            }
        }
        return result.ToList();
    }

    public ProjectItem? GetById(int id)
    {
        return _projects.FirstOrDefault(x => x.Id == id);
    }

    public void Add(ProjectItem project)
    {
        project.Id = _projects.Any() ? _projects.Max(x => x.Id) + 1 : 1;
        _projects.Add(project);
    }

    public void Delete(int id)
    {
        var project = _projects.FirstOrDefault(x => x.Id == id);
        if (project != null)
        {
            _projects.Remove(project);
        }
    }
}
