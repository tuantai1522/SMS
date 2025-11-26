using Microsoft.EntityFrameworkCore;
using SMS.Core.Features.Workspaces;
using SMS.Infrastructure.Database;
using SMS.UseCases.Queries.Workspaces;

namespace SMS.Infrastructure.Queries.Workspaces;

public sealed class GetMenuViewsByRoleIdService(ApplicationDbContext context) : IGetMenuViewsByRoleIdService
{
    public async Task<IReadOnlyList<View>> Handle(Guid roleId, CancellationToken cancellationToken)
    {
        return await (
            from vr in context.Set<ViewRole>()
            join v in context.Set<View>() on vr.ViewId equals v.Id
            where vr.RoleId == roleId &&
                  v.IsMenu &&
                  vr.ViewPermission.AllowRead == ViewAction.SelectedCheck
            orderby v.Order
            select v
        ).ToListAsync(cancellationToken);
    }
}