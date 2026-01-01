using FluentValidation;
using SMS.Core.Errors.Users;

namespace SMS.UseCases.Features.Auths.SignIn;

internal sealed class SignInCommandValidator : AbstractValidator<SignInCommand>
{
    public SignInCommandValidator()
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
