using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Tasks.GetTaskPriorities;

public sealed record GetTaskPrioritiesQuery : IRequest<Result<IReadOnlyList<GetTaskPrioritiesResponse>>>;
