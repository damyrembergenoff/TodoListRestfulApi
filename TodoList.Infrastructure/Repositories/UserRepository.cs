using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;
using TodoList.Infrastructure.Data;

namespace TodoList.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    public async ValueTask<User> CreateAsync(User user)
    {
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
        return user;
    }

    public async ValueTask<User> GetByUsernameAsync(string username)
    {
        return (await dbContext.Users.FirstOrDefaultAsync(u => u.Username == username))!;
    }
}
