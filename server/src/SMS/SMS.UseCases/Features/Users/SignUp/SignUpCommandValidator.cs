using FluentValidation;
using SMS.Core.Errors.Users;

namespace SMS.UseCases.Features.Users.SignUp;

internal sealed class SignUpCommandValidator : AbstractValidator<SignUpCommand>
{
    public SignUpCommandValidator()
    {
        RuleFor(c => c.Email)
            .NotEmpty()
            .WithErrorCode(UserErrorCode.EmailEmpty.ToString())
            .WithMessage("Email can not be empty.");
        
        RuleFor(c => c.Password)
            .NotEmpty()
            .WithErrorCode(UserErrorCode.PasswordEmpty.ToString())
            .WithMessage("Password can not be empty.");
    }
}
