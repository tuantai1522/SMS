using MediatR;
using SMS.Core.Common;
using SMS.Core.Features.Tasks;

namespace SMS.UseCases.Features.Tasks.GetTaskPriorities;

internal sealed class GetTaskStatusesQueryHandler(IRepository<TaskPriority> taskPriorityRepository): IRequestHandler<GetTaskPrioritiesQuery, Result<IReadOnlyList<GetTaskPrioritiesResponse>>>
{
    public async Task<Result<IReadOnlyList<GetTaskPrioritiesResponse>>> Handle(GetTaskPrioritiesQuery query, CancellationToken cancellationToken)
    {
        var taskPriorities = await taskPriorityRepository.FindAllAsync(cancellationToken);
        
        return taskPriorities.Select(taskPriority => new GetTaskPrioritiesResponse(taskPriority.Id, taskPriority.Name)).ToList();
    }
}
