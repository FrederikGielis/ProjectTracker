using ProjectTracker.Domain.Entities;

namespace ProjectTracker.Application.Abstractions;

public interface IUserRepository
{
    List<AppUser> GetAll();
    AppUser? GetById(int id);
}
