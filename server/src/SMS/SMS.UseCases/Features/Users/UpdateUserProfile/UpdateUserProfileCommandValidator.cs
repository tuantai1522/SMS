using FluentValidation;
using SMS.Core.Errors.Users;

namespace SMS.UseCases.Features.Users.UpdateUserProfile;

internal sealed class UpdateUserProfileCommandValidator : AbstractValidator<UpdateUserProfileCommand>
{
    public UpdateUserProfileCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithErrorCode(UserErrorCode.IdEmpty.ToString())
            .WithMessage("Id can not be empty.");
        
        RuleFor(c => c.GivenName)
            .NotEmpty()
            .WithErrorCode(UserErrorCode.GivenNameEmpty.ToString())
            .WithMessage("Given name can not be empty.");
        
        RuleFor(c => c.GivenName)
            .NotEmpty()
            .WithErrorCode(UserErrorCode.GivenNameEmpty.ToString())
            .WithMessage("Given name can not be empty.");
                
        RuleFor(x => x.CountryId)
            .NotEmpty()
            .WithErrorCode(UserErrorCode.CountryIdEmpty.ToString())
            .WithMessage("Country Id  can not be empty.");
        
    }
}
