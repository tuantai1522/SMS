using MediatR;
using SMS.Core.Common;
using SMS.Core.Features.Users;
using SMS.UseCases.Abstractions.Authentication;

namespace SMS.UseCases.Features.Users.SignUp;

internal sealed class SignUpCommandHandler(
    IUnitOfWork unitOfWork,
    IUserRepository userRepository,
    IPasswordHasher passwordHasher): IRequestHandler<SignUpCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(SignUpCommand command, CancellationToken cancellationToken)
    {
        var verifyEmail = await userRepository.VerifyExistedEmailAsync(command.Email, cancellationToken);

        if (verifyEmail)
        {
            return Result.Failure<Guid>(UserErrors.EmailNotUnique);
        }
        
        var verifyNickName = await userRepository.VerifyExistedNickNameAsync(command.NickName, cancellationToken);

        if (verifyNickName)
        {
            return Result.Failure<Guid>(UserErrors.NickNameNotUnique);
        }

        var user = User.CreateUser(
            command.FirstName,
            command.MiddleName, 
            command.LastName, 
            command.NickName, 
            command.Email, 
            passwordHasher.Hash(command.Password),
            command.DateOfBirth, 
            command.GenderType, 
            command.Street, 
            command.CityId);
        
        await userRepository.AddUserAsync(user, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(user.Id);
    }
}
