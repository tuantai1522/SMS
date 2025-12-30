using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.Users;
using SMS.Core.Features.Users;
using SMS.UseCases.Abstractions.Authentication;

namespace SMS.UseCases.Features.Users.GetMe;

internal sealed class GetMeQueryHandler(
    IUserProvider userProvider,
    IUserRepository userRepository): IRequestHandler<GetMeQuery, Result<GetMeResponse>>
{
    public async Task<Result<GetMeResponse>> Handle(GetMeQuery query, CancellationToken cancellationToken)
    {
        var userId = userProvider.UserId;
        var user = await userRepository.FindUserByIdAsync(userId, cancellationToken);
        
        if (user is null)
        {
            return Result.Failure<GetMeResponse>(UserErrors.IdNotFound);
        }

        var response = new GetMeResponse(user.Id, user.UserProfile?.GivenName, user.Email);
        
        return Result.Success(response);
    }
}
