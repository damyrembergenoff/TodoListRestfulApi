using TodoList.Application.DTOs.Auth;
using TodoList.Domain.Entities;
using TodoList.Infrastructure.Security;

namespace TodoList.Application.Mappers;

public static partial class EntityMappers
{
    public static User ToEntity(this RegisterRequest loginRequest)
        => new()
        {
            Id = Guid.NewGuid(),
            PasswordHash = loginRequest.Password.HashPassword(),
            Username = loginRequest.Username
        };
}