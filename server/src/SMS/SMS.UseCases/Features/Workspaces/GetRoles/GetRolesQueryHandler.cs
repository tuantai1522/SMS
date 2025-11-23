using MediatR;
using SMS.Core.Common;
using SMS.Core.Features.Workspaces;

namespace SMS.UseCases.Features.Workspaces.GetRoles;

internal sealed class GetRolesQueryHandler(IRepository<Role> roleRepository): IRequestHandler<GetRolesQuery, Result<IReadOnlyList<GetRolesResponse>>>
{
    public async Task<Result<IReadOnlyList<GetRolesResponse>>> Handle(GetRolesQuery query, CancellationToken cancellationToken)
    {
        var roles = await roleRepository.FindAllAsync(cancellationToken);

        IReadOnlyList<GetRolesResponse> result = roles.Select(role =>  new GetRolesResponse(role.Id, role.Name)).ToList();
        
        return Result.Success(result);
    }
}
