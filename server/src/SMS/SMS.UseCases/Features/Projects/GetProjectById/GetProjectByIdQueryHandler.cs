using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.Projects;
using SMS.Core.Features.Projects;

namespace SMS.UseCases.Features.Projects.GetProjectById;

internal sealed class GetProjectByIdQueryHandler(IProjectRepository projectRepository): IRequestHandler<GetProjectByIdQuery, Result<GetProjectByIdResponse>>
{
    public async Task<Result<GetProjectByIdResponse>> Handle(GetProjectByIdQuery query, CancellationToken cancellationToken)
    {
        var project = await projectRepository.GetProjectByIdAsync(query.Id, cancellationToken);
        
        return project is null ? 
            Result.Failure<GetProjectByIdResponse>(ProjectErrors.CanNotFindProject) : 
            Result.Success(new GetProjectByIdResponse(project.Id, project.Name, project.Code, project.Emoji, project.Description));
    }
}
