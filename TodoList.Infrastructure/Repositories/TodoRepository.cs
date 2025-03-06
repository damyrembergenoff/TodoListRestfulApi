using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;
using TodoList.Infrastructure.Data;

namespace TodoList.Infrastructure.Repositories
{
    public class TodoRepository(ApplicationDbContext dbContext) : ITodoRepository
    {
        public async ValueTask<Todo> CreateAsync(Todo todo)
        {
            dbContext.Todos.Add(todo);
            await dbContext.SaveChangesAsync();
            return todo;
        }

        public async ValueTask DeleteAsync(Todo todo)
        {
            dbContext.Todos.Remove(todo);
            await dbContext.SaveChangesAsync();
        }

        public async ValueTask<Todo> GetByIdAsync(Guid todoId)
            => (await dbContext.Todos.FirstOrDefaultAsync(x => x.Id == todoId))!;

        public async ValueTask<IEnumerable<Todo>> GetByUserIdAsync(Guid userId)
            => await dbContext.Todos.Where(t => t.UserId == userId).ToListAsync();

        public async ValueTask UpdateAsync(Todo todo)
        {
            dbContext.Todos.Update(todo);
            await dbContext.SaveChangesAsync();
        }
    }
}
