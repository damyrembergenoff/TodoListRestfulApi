using TodoList.Application.DTOs.Todos;
using TodoList.Domain.Entities;

namespace TodoList.Application.Mappers;

public static partial class EntityMappers
{
    public static TodoResponse ToDto(this Todo todo)
        => new()
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
            IsCompleted = todo.isCompleted
        };

    public static Todo ToEntity(this TodoCreateRequest todo, Guid userId)
        => new()
        {
            Id = Guid.NewGuid(),
            Title = todo.Title,
            Description = todo.Description,
            UserId = userId
        };

    public static Todo ToEntity(this TodoUpdateRequest todo, Guid userId)
        => new()
        {
            Title = todo.Title,
            Description = todo.Description,
            UserId = userId
        };
}