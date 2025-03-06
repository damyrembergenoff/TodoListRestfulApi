using TodoList.Domain.Entities;

namespace TodoList.Domain.Interfaces;

public interface IUserRepository
{
    ValueTask<User> GetByUsernameAsync(string username);
    ValueTask<User> CreateAsync(User user);
}