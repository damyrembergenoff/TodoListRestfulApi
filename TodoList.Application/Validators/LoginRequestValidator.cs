using FluentValidation;
using TodoList.Application.DTOs.Auth;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username bo'sh bo'lmasligi kerak.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Parol bo'sh bo'lmasligi kerak.");
    }
}