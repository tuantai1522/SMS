using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Users.SignOut;

public sealed record SignOutCommand : IRequest<Result<bool>>;
