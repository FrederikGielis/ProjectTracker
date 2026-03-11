using ProjectTracker.Domain.Entities;

namespace ProjectTracker.Application.Abstractions;

public interface IProjectRepository
{
    List<ProjectItem> GetAll();
    List<ProjectItem> GetByMaxBudget(decimal maxBudget);
    ProjectItem? GetById(int id);
    void Add(ProjectItem project);
    void Delete(int id);
}
