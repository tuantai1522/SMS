using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.Projects;
using SMS.Core.Features.Projects;

namespace SMS.UseCases.Features.Projects.GetProjectByIdAndWorkspaceId;

internal sealed class GetProjectByIdAndWorkspaceIdQueryHandler(IProjectRepository projectRepository): IRequestHandler<GetProjectByIdAndWorkspaceIdQuery, Result<GetProjectByIdAndWorkspaceIdResponse>>
{
    public async Task<Result<GetProjectByIdAndWorkspaceIdResponse>> Handle(GetProjectByIdAndWorkspaceIdQuery query, CancellationToken cancellationToken)
    {
        var project = await projectRepository.GetProjectByIdAndWorkspaceIdAsync(query.Id, query.WorkspaceId, cancellationToken);
        
        return project is null ? 
            Result.Failure<GetProjectByIdAndWorkspaceIdResponse>(ProjectErrors.CanNotFindProject) : 
            Result.Success(new GetProjectByIdAndWorkspaceIdResponse(project.Id, project.Name, project.Code, project.Emoji, project.Description));
    }
}
