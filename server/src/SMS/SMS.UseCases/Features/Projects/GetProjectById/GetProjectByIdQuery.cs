using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Projects.GetProjectById;

public sealed record GetProjectByIdQuery(Guid Id) : IRequest<Result<GetProjectByIdResponse>>;
