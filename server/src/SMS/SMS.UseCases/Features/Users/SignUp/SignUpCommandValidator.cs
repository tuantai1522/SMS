using FluentValidation;

namespace SMS.UseCases.Features.Users.SignUp;

internal sealed class SignUpCommandValidator : AbstractValidator<SignUpCommand>
{
    public SignUpCommandValidator()
    {
        RuleFor(c => c.FirstName)
            .NotEmpty().WithMessage("First name can not be empty.");
        
        RuleFor(c => c.NickName)
            .NotEmpty().WithMessage("Nick name can not be empty.");
        
        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Email can not be empty.");
        
        RuleFor(c => c.Password)
            .NotEmpty().WithMessage("Password can not be empty.");
        
        RuleFor(x => x.GenderType)
            .IsInEnum().WithMessage("GenderType must be 'Male' or 'Female' or 'Other'");
        
        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("Street can not be empty.");
        
        RuleFor(x => x.CityId)
            .NotEmpty().WithMessage("CityId can not be empty.");
    }
}
