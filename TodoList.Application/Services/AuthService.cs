using TodoList.Application.DTOs.Auth;
using TodoList.Application.Interfaces;
using TodoList.Application.Mappers;
using TodoList.Domain.Interfaces;
using TodoList.Infrastructure.Security;

namespace TodoList.Application.Services;

public class AuthService(IUserRepository repository, JwtTokenGeneretor jwtTokenGeneretor) : IAuthService
{
    public async ValueTask<AuthResponse> LoginAsync(LoginRequest request)
    {
        var user = await repository.GetByUsernameAsync(request.Username);
        if (user == null)
            throw new Exception("User not found.");

        if (!request.Password.VerifyPassword(user.PasswordHash))
            throw new Exception("Invalid credentials.");

        var token = jwtTokenGeneretor.GenerateToken(user.Id, user.Username);

        return new AuthResponse
        {
            Token = token.Token,
            Expiration = token.Expiration
        };
    }

    public async ValueTask<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        var existingUser = await repository.GetByUsernameAsync(request.Username);
        if (existingUser != null)
            throw new Exception("Username already exists.");

        var create = await repository.CreateAsync(request.ToEntity());

        var tokenResult = jwtTokenGeneretor.GenerateToken(create.Id, create.Username);

        return new AuthResponse
        {
            Token = tokenResult.Token,
            Expiration = tokenResult.Expiration
        };
    }
}