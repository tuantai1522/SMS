using FluentValidation;

namespace SMS.UseCases.Features.Users.SignIn;

internal sealed class SignInCommandValidator : AbstractValidator<SignInCommand>
{
    public SignInCommandValidator()
    {
        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Email can not be empty.");

        RuleFor(c => c.Password)
            .NotEmpty().WithMessage("Password can not be empty.");
    }
}
