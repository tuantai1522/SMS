using MediatR;
using SMS.Core.Common;
namespace SMS.UseCases.Features.Auths.SignUp;

public sealed record SignUpCommand(string GivenName, string Email, string Password) : IRequest<Result<Guid>>;
