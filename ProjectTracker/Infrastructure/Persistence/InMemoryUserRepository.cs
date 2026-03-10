using ProjectTracker.Application.Abstractions;
using ProjectTracker.Domain.Entities;

namespace ProjectTracker.Infrastructure.Persistence;

public class InMemoryUserRepository : IUserRepository
{
    private readonly List<AppUser> _users =
    [
        new AppUser
        {
            Id = 1,
            Name = "Alice",
            Email = "alice@cegeka.com",
            IsActive = true
        },
        new AppUser
        {
            Id = 2,
            Name = "Bob",
            Email = "bob@cegeka.com",
            IsActive = true
        },
        new AppUser
        {
            Id = 3,
            Name = "Charlie",
            Email = "charlie@cegeka.com",
            IsActive = false
        }
    ];

    public List<AppUser> GetAll()
    {
        return _users;
    }

    public AppUser? GetById(int id)
    {
        return _users.FirstOrDefault(x => x.Id == id);
    }
}
