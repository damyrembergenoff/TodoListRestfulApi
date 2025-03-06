

using TodoList.Application.DTOs.Todos;

namespace TodoList.Application.Interfaces
{
    public interface ITodoService
    {
        ValueTask<TodoResponse> CreateTodoAsync(Guid userId, TodoCreateRequest todoCreateRequestDto);
        
        ValueTask<IEnumerable<TodoResponse>> GetTodosAsync(Guid userId);
        
        ValueTask<TodoResponse> GetTodoByIdAsync(Guid userId, Guid todoId);
        
        ValueTask UpdateTodoAsync(Guid userId, Guid todoId, TodoUpdateRequest todoUpdateRequestDto);
        
        ValueTask DeleteTodoAsync(Guid userId, Guid todoId);
    }
}
