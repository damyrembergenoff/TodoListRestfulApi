namespace TodoList.Application.DTOs.Todos;

public class TodoCreateRequest
{
    public required string Title { get; set; }
    public string? Description { get; set; }
}