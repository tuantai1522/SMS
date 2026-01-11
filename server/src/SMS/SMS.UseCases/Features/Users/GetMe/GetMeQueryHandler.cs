using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.Users;
using SMS.UseCases.Abstractions.Authentication;
using SMS.UseCases.Queries.Users;

namespace SMS.UseCases.Features.Users.GetMe;

internal sealed class GetMeQueryHandler(
    IUserProvider userProvider,
    IGetMeService getMeService): IRequestHandler<GetMeQuery, Result<GetMeResponse>>
{
    public async Task<Result<GetMeResponse>> Handle(GetMeQuery query, CancellationToken cancellationToken)
    {
        var userId = userProvider.UserId;
        var user = await getMeService.Handle(userId, cancellationToken);
        
        return user is null ? Result.Failure<GetMeResponse>(UserErrors.IdNotFound) : Result.Success(user);
    }
}
