using Microsoft.EntityFrameworkCore;
using SMS.Core.Features.Users;
using SMS.UseCases.Abstractions.Data;
using SMS.UseCases.Features.Users.GetMe;
using SMS.UseCases.Queries.Users;

namespace SMS.Infrastructure.Queries.Users;

public sealed class GetMeService(IApplicationDbContext context) : IGetMeService
{
    public async Task<GetMeResponse?> Handle(Guid userId, CancellationToken cancellationToken)
    {
        return await (
            from u in context.Set<User>()
            join up in context.Set<UserProfile>() on u.Id equals up.UserId
            where u.Id == userId
            select new GetMeResponse(u.Id, up.GivenName, u.Email, up.AvatarUrl)
        ).FirstOrDefaultAsync(cancellationToken);
    }
}