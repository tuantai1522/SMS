using MediatR;
using SMS.Core.Common;
using SMS.Core.Features.Tasks;
using SMS.UseCases.Pagination.OffsetPagination;

namespace SMS.UseCases.Features.Tasks.GetTasksByWorkspaceId;

internal sealed class GetTasksByWorkspaceIdQueryHandler(
    ITaskRepository taskRepository): IRequestHandler<GetTasksByWorkspaceIdQuery, Result<OffsetPaginationResponse<GetTasksByWorkspaceIdResponse>>>
{
    public async Task<Result<OffsetPaginationResponse<GetTasksByWorkspaceIdResponse>>> Handle(GetTasksByWorkspaceIdQuery query, CancellationToken cancellationToken)
    {
        var queryable = taskRepository.GetTasksOrderByProjectNameAsync(query.WorkspaceId, query.ProjectId, query.StatusIds, query.PriorityIds,
            query.AssignedToIds, query.KeyWord, query.DueDate, query.IsAscending, cancellationToken);
        
        var paginated = await OffsetPaginationResponse<GetTasksByWorkspaceIdResponse>.CreateAsync(
            queryable.Select(task => new GetTasksByWorkspaceIdResponse(
                task.Id,
                task.Code,
                task.Name,
                task.Project.Name,
                task.AssignedTo != null ? task.AssignedTo.FirstName : null,
                task.AssignedTo != null ? task.AssignedTo.MiddleName : null,
                task.AssignedTo != null ? task.AssignedTo.LastName : null,
                task.DueDate,
                task.TaskStatus.Name,
                task.TaskPriority.Name
            )),
            query.Page,
            query.PageSize,
            cancellationToken
        );

        return Result.Success(paginated);
    }
}
