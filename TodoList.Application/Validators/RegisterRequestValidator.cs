using FluentValidation;
using TodoList.Application.DTOs.Auth;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username bo'sh bo'lmasligi kerak.")
            .MinimumLength(3).WithMessage("Username kamida 3 belgidan iborat bo'lishi kerak.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Parol bo'sh bo'lmasligi kerak.")
            .MinimumLength(6).WithMessage("Parol kamida 6 belgidan iborat bo'lishi kerak.");
    }
}
