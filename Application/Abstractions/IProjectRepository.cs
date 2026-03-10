using ProjectTracker.Domain.Entities;

namespace ProjectTracker.Application.Abstractions;

public interface IProjectRepository
{
    List<ProjectItem> GetAll();
    ProjectItem? GetById(int id);
    void Add(ProjectItem project);
    void Delete(int id);
}
