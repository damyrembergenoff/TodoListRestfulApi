namespace TodoList.Application.DTOs.Todos;

public class TodoUpdateRequest
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
}