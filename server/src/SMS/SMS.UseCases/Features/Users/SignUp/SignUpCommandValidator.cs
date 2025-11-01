using FluentValidation;
using SMS.Core.Errors.Users;

namespace SMS.UseCases.Features.Users.SignUp;

internal sealed class SignUpCommandValidator : AbstractValidator<SignUpCommand>
{
    public SignUpCommandValidator()
    {
        RuleFor(c => c.FirstName)
            .NotEmpty()
            .WithErrorCode(UserErrorCode.FirstNameEmpty.ToString())
            .WithMessage("First name can not be empty.");
        
        RuleFor(c => c.NickName)
            .NotEmpty()
            .WithErrorCode(UserErrorCode.NickNameEmpty.ToString())
            .WithMessage("Nick name can not be empty.");
        
        RuleFor(c => c.Email)
            .NotEmpty()
            .WithErrorCode(UserErrorCode.EmailEmpty.ToString())
            .WithMessage("Email can not be empty.");
        
        RuleFor(c => c.Password)
            .NotEmpty()
            .WithErrorCode(UserErrorCode.PasswordEmpty.ToString())
            .WithMessage("Password can not be empty.");
        
        RuleFor(x => x.GenderType)
            .IsInEnum()
            .WithErrorCode(UserErrorCode.InvalidGenderType.ToString())
            .WithMessage("GenderType must be 'Male' or 'Female' or 'Other'");
        
        RuleFor(x => x.Street)
            .NotEmpty()
            .WithErrorCode(UserErrorCode.AddressStreetEmpty.ToString())
            .WithMessage("Street can not be empty.");
        
        RuleFor(x => x.CityId)
            .NotEmpty()
            .WithErrorCode(UserErrorCode.CityIdEmpty.ToString())
            .WithMessage("CityId can not be empty.");
    }
}
