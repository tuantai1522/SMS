using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Tasks.GetTaskStatuses;

public sealed record GetTaskStatusesQuery : IRequest<Result<IReadOnlyList<GetTaskStatusesResponse>>>;
