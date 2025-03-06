using TodoList.Domain.Entities;

namespace TodoList.Domain.Interfaces;

public interface ITodoRepository
{
    ValueTask<Todo> CreateAsync(Todo todo);
    ValueTask<Todo> GetByIdAsync(Guid todoId);
    ValueTask UpdateAsync(Todo todo);
    ValueTask DeleteAsync(Todo todo);
    ValueTask<IEnumerable<Todo>> GetByUserIdAsync(Guid userId);
}