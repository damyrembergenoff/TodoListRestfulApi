namespace TodoList.Infrastructure.Security;

public class ResultToken
{
    public string? Token { get; set; }
    public DateTime Expiration { get; set; }
}