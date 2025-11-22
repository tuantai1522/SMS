using MediatR;
using SMS.Core.Common;
using TaskStatus = SMS.Core.Features.Tasks.TaskStatus;

namespace SMS.UseCases.Features.Tasks.GetTaskStatuses;

internal sealed class GetTaskStatusesQueryHandler(IRepository<TaskStatus> taskStatusRepository): IRequestHandler<GetTaskStatusesQuery, Result<IReadOnlyList<GetTaskStatusesResponse>>>
{
    public async Task<Result<IReadOnlyList<GetTaskStatusesResponse>>> Handle(GetTaskStatusesQuery query, CancellationToken cancellationToken)
    {
        var taskStatuses = await taskStatusRepository.FindAllAsync(cancellationToken);
        
        return taskStatuses.Select(taskStatus => new GetTaskStatusesResponse(taskStatus.Id, taskStatus.Name)).ToList();
    }
}
