using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Tasks.CreateTask;

public sealed record CreateTaskCommand(
    string Name, string? Description, Guid ProjectId, Guid StatusId, 
    Guid PriorityId, Guid? AssignedTo, long? StartDate, long? DueDate) : IRequest<Result<Guid>>;
