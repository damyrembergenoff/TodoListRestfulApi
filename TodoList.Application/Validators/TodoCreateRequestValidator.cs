using FluentValidation;
using TodoList.Application.DTOs.Todos;

public class TodoCreateRequestValidator : AbstractValidator<TodoCreateRequest>
{
    public TodoCreateRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title bo'sh bo'lmasligi kerak.")
            .MaximumLength(255).WithMessage("Title 255 belgidan oshmasligi kerak.");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Description 1000 belgidan oshmasligi kerak.");
    }
}