using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.Users;
using SMS.Core.Features.Users;
using SMS.UseCases.Abstractions.Authentication;
using SMS.UseCases.Abstractions.Data;

namespace SMS.UseCases.Features.Users.SignUp;

internal sealed class SignUpCommandHandler(
    IUnitOfWork unitOfWork,
    IUserRepository userRepository,
    IUserProvider userProvider,
    IPasswordHasher passwordHasher): IRequestHandler<SignUpCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(SignUpCommand command, CancellationToken cancellationToken)
    {
        var verifyEmail = await userRepository.VerifyExistedEmailAsync(command.Email, cancellationToken);

        if (verifyEmail)
        {
            return Result.Failure<Guid>(UserErrors.EmailNotUnique);
        }

        var (token, expiredAt) = userProvider.GenerateTokenAndExpiredAtForUserSignedUp();
        
        // Todo: To add service sending email to verify mail
        var user = User.CreateUser(command.Email, passwordHasher.Hash(command.Password), UserStatus.Active, token, expiredAt);
        
        await userRepository.AddUserAsync(user, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(user.Id);
    }
}
