using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Auths.SignOut;

public sealed record SignOutCommand : IRequest<Result<bool>>;
