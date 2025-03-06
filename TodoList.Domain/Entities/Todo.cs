namespace TodoList.Domain.Entities;

public class Todo
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public bool isCompleted { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
}