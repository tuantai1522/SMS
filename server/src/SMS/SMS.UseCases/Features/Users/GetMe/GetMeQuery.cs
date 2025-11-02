using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Users.GetMe;

public sealed record GetMeQuery : IRequest<Result<GetMeResponse>>;
