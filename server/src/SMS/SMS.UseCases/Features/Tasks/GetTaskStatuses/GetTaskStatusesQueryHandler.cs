using MediatR;
using SMS.Core.Common;
using SMS.Core.Features.Tasks;

namespace SMS.UseCases.Features.Tasks.GetTaskStatuses;

internal sealed class GetTaskStatusesQueryHandler(ITaskStatusRepository taskStatusRepository): IRequestHandler<GetTaskStatusesQuery, Result<IReadOnlyList<GetTaskStatusesResponse>>>
{
    public async Task<Result<IReadOnlyList<GetTaskStatusesResponse>>> Handle(GetTaskStatusesQuery query, CancellationToken cancellationToken)
    {
        var taskStatuses = await taskStatusRepository.GetTaskStatusesAsync(cancellationToken);
        
        return taskStatuses.Select(taskStatus => new GetTaskStatusesResponse(taskStatus.Id, taskStatus.Name)).ToList();
    }
}
