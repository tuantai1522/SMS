using MediatR;
using SMS.Core.Common;
namespace SMS.UseCases.Features.Users.SignUp;

public sealed record SignUpCommand(string Email, string Password) : IRequest<Result<Guid>>;
