using FluentValidation;
using SMS.Core.Errors.Users;

namespace SMS.UseCases.Features.Users.UpdateUserProfile;

internal sealed class UpdateUserProfileCommandValidator : AbstractValidator<UpdateUserProfileCommand>
{
    public UpdateUserProfileCommandValidator()
    {
        RuleFor(c => c.GivenName)
            .NotEmpty()
            .WithErrorCode(UserErrorCode.GivenNameEmpty.ToString())
            .WithMessage("Given name can not be empty.");
        
        RuleFor(c => c.GivenName)
            .NotEmpty()
            .WithErrorCode(UserErrorCode.GivenNameEmpty.ToString())
            .WithMessage("Given name can not be empty.");
    }
}
