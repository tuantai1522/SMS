using Microsoft.EntityFrameworkCore;
using SMS.Core.Common;
using SMS.Core.Errors.Users;
using SMS.Core.Features.Users;
using SMS.UseCases.Abstractions.Data;
using SMS.UseCases.Commands.Users;
using SMS.UseCases.Features.Users.UpdateUserProfile;

namespace SMS.Infrastructure.Commands.Users;

public class UpdateUserProfileService(IUnitOfWork unitOfWork, IApplicationDbContext context) : IUpdateUserProfileService
{
    public async Task<Result<Guid>> Handle(Guid userId, UpdateUserProfileCommand command, CancellationToken cancellationToken)
    {
        var user = await context.Set<User>()
            .Include(user => user.UserProfile)
            .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        
        if (user == null)
        {
            return Result.Failure<Guid>(UserErrors.IdNotFound);
        }
        
        user.UpdateUserProfile(command.GivenName, command.AvatarUrl);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(user.Id);
    }
}