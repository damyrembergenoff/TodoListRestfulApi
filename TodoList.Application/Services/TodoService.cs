using TodoList.Application.DTOs.Todos;
using TodoList.Application.Interfaces;
using TodoList.Application.Mappers;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.Services;

public class TodoService(ITodoRepository repository) : ITodoService
{
    public async ValueTask<TodoResponse> CreateTodoAsync(Guid userId, TodoCreateRequest todoCreateRequestDto)
    {
        var todoResponse = await repository.CreateAsync(todoCreateRequestDto.ToEntity(userId));
        return todoResponse.ToDto();
    }

    public async ValueTask DeleteTodoAsync(Guid userId, Guid todoId)
    {
        var todo = await repository.GetByIdAsync(todoId);

        if(todo is null || todo.UserId != userId)
            throw new Exception("Todo not found or access denied");

        await repository.DeleteAsync(todo);
    }

    public async ValueTask<TodoResponse> GetTodoByIdAsync(Guid userId, Guid todoId)
    {
        var todo = await repository.GetByIdAsync(todoId);

        if(todo is null || todo.UserId != userId)
            throw new Exception("Todo not found or access denied");

        return todo.ToDto();
    }

    public async ValueTask<IEnumerable<TodoResponse>> GetTodosAsync(Guid userId)
    {
        var todos = await repository.GetByUserIdAsync(userId);
        return todos.Select(x => x.ToDto());
    }

    public async ValueTask UpdateTodoAsync(Guid userId, Guid todoId, TodoUpdateRequest todoUpdateRequestDto)
    {
        var todo = await repository.GetByIdAsync(todoId);
        
        if(todo is null || todo.UserId != userId)
            throw new Exception("Todo not found or access denied");
        
        await repository.UpdateAsync(todo);
    }
}
