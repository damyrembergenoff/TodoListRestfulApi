using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Application.DTOs.Todos;
using TodoList.Application.Interfaces;

namespace TodoList.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class TodosController(ITodoService service) : ControllerBase
{
    private Guid GetUserIdFromToken()
    {
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        if (userIdClaim is null)
            throw new Exception("User Id not found in token");
        return Guid.Parse(userIdClaim.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        var userId = GetUserIdFromToken();
        var todos = await service.GetTodosAsync(userId);
        return Ok(todos);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTodo([FromBody] TodoCreateRequest request)
    {
        var userId = GetUserIdFromToken();
        var createdTodo = await service.CreateTodoAsync(userId, request);
        return CreatedAtAction(nameof(GetTodoById), new { id = createdTodo.Id }, createdTodo);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetTodoById(Guid id)
    {
        var userId = GetUserIdFromToken();
        var todo = await service.GetTodoByIdAsync(userId, id);
        return Ok(todo);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateTodo(Guid id, [FromBody] TodoUpdateRequest request)
    {
        var userId = GetUserIdFromToken();
        await service.UpdateTodoAsync(userId, id, request);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTodo(Guid id)
    {
        var userId = GetUserIdFromToken();
        await service.DeleteTodoAsync(userId, id);
        return NoContent();
    }
}