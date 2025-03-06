using TodoList.Application.DTOs.Auth;

namespace TodoList.Application.Interfaces;

public interface IAuthService
{
    ValueTask<AuthResponse> RegisterAsync(RegisterRequest request);
    ValueTask<AuthResponse> LoginAsync(LoginRequest request);
}