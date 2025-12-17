using Microsoft.EntityFrameworkCore;
using SMS.Core.Features.Projects;
using SMS.UseCases.Abstractions.Data;
using SMS.UseCases.Queries.Projects;

namespace SMS.Infrastructure.Queries.Projects;

public sealed class VerifyExistedProjectCodeByWorkspaceIdService(IApplicationDbContext context) : IVerifyExistedProjectCodeByWorkspaceIdService
{
    public async Task<bool> Handle(string code, Guid workspaceId, CancellationToken cancellationToken)
    {
        return await context.Set<Project>()
            .AnyAsync(
                p => p.Code == code && p.WorkspaceId == workspaceId,
                cancellationToken
            );
    }
}