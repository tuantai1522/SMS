using FluentValidation;
using SMS.Core.Errors.Tasks;

namespace SMS.UseCases.Features.Tasks.CreateTask;

internal sealed class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithErrorCode(TaskErrorCode.NameEmpty.ToString())
            .WithMessage("Name can not be empty.");

        RuleFor(c => c.ProjectId)
            .NotEmpty()
            .WithErrorCode(TaskErrorCode.ProjectIdEmpty.ToString())
            .WithMessage("Project Id can not be empty.");
        
        RuleFor(c => c.StatusId)
            .NotEmpty()
            .WithErrorCode(TaskErrorCode.StatusIdEmpty.ToString())
            .WithMessage("Status Id can not be empty.");
        
        RuleFor(c => c.PriorityId)
            .NotEmpty()
            .WithErrorCode(TaskErrorCode.PriorityIdEmpty.ToString())
            .WithMessage("Priority Id can not be empty.");
    }
}
